using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Data;
using ScholarStack.Models;

namespace ScholarStack.Pages
{
    public class LoginModel : PageModel
    {
        
        private readonly ScholarStackDBContext _dbContext;

        [BindProperty(SupportsGet = true)]
        public User? user { get; set; } = default!;
        
        public LoginModel(ScholarStackDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public void OnPost() {
            
        }

        [HttpPost]
        public IActionResult OnPostRegister()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create a new User object with the submitted data
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
                GoogleScholarURL = user.GoogleScholarURL
            };

            // Add the new user to the DbContext and save changes
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return RedirectToPage("Index");
        }

		public IActionResult OnPostLogin()
		{
			return RedirectToPage("Index");
		}
	}
}
