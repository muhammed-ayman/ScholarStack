using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Models;

namespace ScholarStack.Pages
{
    public class LoginModel : PageModel
    {
        
        private readonly DB_Manager _dbManager;

        [BindProperty]
        public User u { get; set; }
        
        public LoginModel(DB_Manager db)
        {
            _dbManager = db;
        }
        public void OnGet()
        {
        }

        public void OnPost() {
            
        }
        
        public IActionResult OnPostRegister()
        {
            
            return RedirectToPage("Index");
        }

		public IActionResult OnPostLogin()
		{
			return RedirectToPage("Index");
		}
	}
}
