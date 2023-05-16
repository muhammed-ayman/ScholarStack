using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Models;

namespace ScholarStack.Pages
{
    public class LoginModel : PageModel
    {
        
        private readonly DB_Manager _dbManager;

        [BindProperty(SupportsGet = true)]
        public User? user { get; set; } = default!;
        
        public LoginModel(DB_Manager db)
        {
            _dbManager = db;
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

            return RedirectToPage("Index");
        }

		public IActionResult OnPostLogin()
		{
			return RedirectToPage("Index");
		}
	}
}
