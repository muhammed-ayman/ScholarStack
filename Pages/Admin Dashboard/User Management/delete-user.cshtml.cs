using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScholarStack.Pages.Admin_Dashboard.User_Management
{
	public class delete_userModel : PageModel
	{

		private readonly ScholarStackDBContext _dbContext;
		public List<User> Users { get; set; }

		public delete_userModel(ScholarStackDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void OnGet()
		{
			Users = _dbContext.User.Include(u => u.Role).ToList();
		}

		public async Task<IActionResult> OnDeleteAsync(int id)
		{
			var user = await _dbContext.User.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			_dbContext.User.Remove(user);
			await _dbContext.SaveChangesAsync();

			return new EmptyResult();
		}
	}
}