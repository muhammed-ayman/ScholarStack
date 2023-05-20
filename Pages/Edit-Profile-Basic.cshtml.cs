using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Data;
using ScholarStack.Models;
using ScholarStack.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ScholarStack.Pages
{
    public class Edit_Profile_BasicModel : PageModel
    {

		private readonly ILogger<IndexModel> _logger;
		private readonly ScholarStackDBContext _dbContext;
		
		[BindProperty]
		public User AuthenticatedUser { get; set; }

		[BindProperty(Name = "UpdateViewModel")]
		public UpdateViewModel? UpdateViewModel { get; set; }

		public Edit_Profile_BasicModel(ILogger<IndexModel> logger, ScholarStackDBContext dBContext)
		{
			_logger = logger;
			_dbContext = dBContext;
		}
		public void OnGet()
		{
			RetrieveAuthenticatedUser();
		}

		private void RetrieveAuthenticatedUser()
		{
			AuthenticatedUser = _dbContext.User.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("UserName"));
		}

		public IActionResult OnPost()
		{
			var validationResults = new List<ValidationResult>();
			var context = new ValidationContext(UpdateViewModel);

			// Manually perform validation
			bool isValid = Validator.TryValidateObject(UpdateViewModel, context, validationResults, true);

			if (!isValid)
			{
				RetrieveAuthenticatedUser();
				return Page();
			}
			User userToUpdate = _dbContext.User.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("UserName"));
			if (userToUpdate != null)
			{
				userToUpdate.FirstName = UpdateViewModel.FirstName;
				userToUpdate.LastName = UpdateViewModel.LastName;
				userToUpdate.Email = UpdateViewModel.Email;
				userToUpdate.GoogleScholarURL = UpdateViewModel.GoogleScholarURL;

				_dbContext.User.Update(userToUpdate);
				_dbContext.SaveChanges();
			}

			return RedirectToPage("Index");
		}
	}
}
