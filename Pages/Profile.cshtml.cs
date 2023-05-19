using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ScholarStack.Data;
using ScholarStack.Models;
using System;

namespace ScholarStack.Pages
{
    public class ProfileModel : PageModel
    {
		private readonly ILogger<IndexModel> _logger;
		private readonly ScholarStackDBContext _dbContext;
		public User AuthenticatedUser { get; set; }

		public ProfileModel(ILogger<IndexModel> logger, ScholarStackDBContext dBContext)
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
	}
}
