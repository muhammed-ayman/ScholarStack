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
                .Include(p => p.Votes) // Eagerly load the associated votes
                .Select(p => new CommunityPost
                {
                    ID = p.ID,
                    Content = p.Content,
                    TimeStamp = p.TimeStamp,
                    CreatorID = p.CreatorID,
                    User = p.User,
                    Attachment = p.Attachment,
                    Votes = p.Votes, // Assign the loaded votes to the Votes property
                    Comments = _dbContext.CommunityPostComment
                        .Include(c => c.Comment)
                        .Where(c => c.CommunityPostID == p.ID)
                        .ToList()
                })
                .AsEnumerable()
                .ToList();

            foreach (var communityPost in CommunityPosts)
            {
                communityPost.Score = CalculateScore(communityPost); // Calculate the score for each community post
            }

            CommunityPosts = CommunityPosts
                .OrderByDescending(p => p.Score) // Order the posts by score in descending order
                .ToList();
        }


        private double CalculateScore(CommunityPost post)
        {
            const double upvoteWeight = 1.5; // Weight for upvotes
            const double downvoteWeight = -0.5; // Weight for downvotes
            const double timeWeight = 0.1; // Weight for time (adjust as needed)
            const double timeDecayRate = 0.05; // Rate at which the time weight decreases (adjust as needed)

            int upvotes = _dbContext.Vote.Count(v => v.CommunityPostID == post.ID && v.VoteType);
            int downvotes = _dbContext.Vote.Count(v => v.CommunityPostID == post.ID && !v.VoteType);

            TimeSpan timeSinceCreation = DateTime.UtcNow - post.TimeStamp;
            
            // Calculate the time weight using a logarithmic function
            double timeWeightFactor = Math.Pow(Math.E, -timeDecayRate * timeSinceCreation.TotalHours);
            
            // Calculate the score using the updated scoring formula
            double score = (upvotes * upvoteWeight) + (downvotes * downvoteWeight) + (timeWeight * timeWeightFactor);

            return score;
        }
    }
}
