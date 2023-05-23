using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;

namespace ScholarStack.Pages.Admin_Dashboard
{
    public class user_managementModel : PageModel
    {
		private readonly ScholarStackDBContext _dbContext;
		public List<User> Users { get; set; }

		public user_managementModel(ScholarStackDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void OnGet()
		{
			RerieveUsers();
		}

		private void RerieveUsers()
		{
			Users = _dbContext.User.Include(u => u.Role).ToList();
		}

		public IActionResult OnPostDeleteUser(int id)
		{
			var user = _dbContext.User.Find(id);
			if (user == null)
			{
				return NotFound();
			}
			_dbContext.User.Remove(user);
			_dbContext.SaveChanges();
			return new JsonResult("User deleted successfully");
		}
	}
}
