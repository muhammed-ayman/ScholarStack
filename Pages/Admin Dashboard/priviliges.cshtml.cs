using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;
using ScholarStack.ViewModels;
using System.Collections.Generic;

namespace ScholarStack.Pages.Admin_Dashboard
{
	public class priviliges : PageModel
	{
		private readonly ScholarStackDBContext _dbContext;
		public List<Privilege> Privileges { get; set; }

		public priviliges(ScholarStackDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void OnGet()
		{
			RetrievePrivileges();
		}

		private void RetrievePrivileges()
		{
			Privileges = _dbContext.Privilege.Select(p => new Privilege
			{
				privilege_name = p.privilege_name
			})
				.ToList();
		}
	}
}