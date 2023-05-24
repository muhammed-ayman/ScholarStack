using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Data;
using ScholarStack.Models;
using ScholarStack.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ScholarStack.Pages.Admin_Dashboard
{
	public class addpriviliges : PageModel
	{

		private readonly ILogger<addpriviliges> _logger;
		private readonly ScholarStackDBContext _dbContext;

		[BindProperty]
		public AddPriviligeViewModel AddPriviligeViewModel { get; set; }

		public addpriviliges(ILogger<addpriviliges> logger, ScholarStackDBContext dBContext)
		{
			_logger = logger;
			_dbContext = dBContext;
		}
		[HttpPost]
		public IActionResult OnPost()
		{
			var validationResults = new List<ValidationResult>();
			var context = new ValidationContext(AddPriviligeViewModel);

			// Manually perform validation
			bool isValid = Validator.TryValidateObject(AddPriviligeViewModel, context, validationResults, true);

			if (!isValid)
			{
				return Page();
			}

			/*	if (!ModelState.IsValid)
				{
					return Page();
				}*/

			Privilege newPrivilige = new Privilege
			{
				privilege_name = AddPriviligeViewModel.privilege_name
			};

			_dbContext.Privilege.Add(newPrivilige);
			_dbContext.SaveChanges();

			TempData["SuccessMessage"] = "Your privilege has been added successfully!";

			return RedirectToPage();
		}
	}
}
