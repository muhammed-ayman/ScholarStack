using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using ScholarStack.Data;
using ScholarStack.ViewModels;
using ScholarStack.Models;

namespace ScholarStack.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ScholarStackDBContext _dbContext;

        public List<CommunityPost> CommunityPosts { get; set; }

        [BindProperty(Name = "createCPostViewModel")]
        public CPostViewModel CreateCPostViewModel { get; set; }

        public User AuthenticatedUser { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ScholarStackDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            RetrieveAuthenticatedUser();
            RetrievePosts();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostCreatePost()
        {
            RetrieveAuthenticatedUser();
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(CreateCPostViewModel);

            // Manually perform validation
            bool isValid = Validator.TryValidateObject(CreateCPostViewModel, context, validationResults, true);

            if (!isValid)
            {
                // Re-populate the posts after validation failure
                RetrievePosts();

                return Page();
            }

            CommunityPost communityPost = new CommunityPost
            {
                Content = CreateCPostViewModel.Content,
                CreatorID = AuthenticatedUser.ID
            };

            // Save the post to the database or perform other necessary actions
            _dbContext.CommunityPost.Add(communityPost);
            _dbContext.SaveChanges();

            if (CreateCPostViewModel.PostImageAttachment != null && CreateCPostViewModel.PostImageAttachment.Length > 0)
            {
                // Handle post image attachment if uploaded
                string imageFileName = await UploadImage(CreateCPostViewModel.PostImageAttachment);

                CommunityPostAttachment communityPostAttachment = new CommunityPostAttachment
                {
                    URL = imageFileName,
                    CommunityPostID = communityPost.ID
                };

                // Save the post image attachment to the database or perform other necessary actions
                _dbContext.CommunityPostAttachment.Add(communityPostAttachment);
                _dbContext.SaveChanges();
            }

            TempData["SuccessMessage"] = "Your post has been published successfully!";

            return RedirectToPage();
        }

        private async Task<string> UploadImage(IFormFile imageFile)
        {
            string uniqueFileName = $"{Guid.NewGuid()}_{imageFile.FileName}";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "post attachments", uniqueFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

        private void RetrieveAuthenticatedUser()
        {
            string userName = HttpContext.Session.GetString("UserName");
            AuthenticatedUser = _dbContext.User.FirstOrDefault(u => u.Username == userName);
        }

        private void RetrievePosts()
        {
            CommunityPosts = _dbContext.CommunityPost
                .Include(p => p.User)
                .Include(p => p.Attachment)
                .Select(p => new CommunityPost
                {
                    ID = p.ID,
                    Content = p.Content,
                    TimeStamp = p.TimeStamp,
                    CreatorID = p.CreatorID,
                    User = p.User,
                    Attachment = p.Attachment
                })
                .ToList();
        }
    }
}
