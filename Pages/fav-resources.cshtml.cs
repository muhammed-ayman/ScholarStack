using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Data;
using ScholarStack.Models;

namespace ScholarStack.Pages
{
    public class fav_resourcesModel : PageModel
    {

		private readonly ILogger<IndexModel> _logger;
		private readonly ScholarStackDBContext _dbContext;

		public User AuthenticatedUser { get; set; }

		public fav_resourcesModel(ILogger<IndexModel> logger, ScholarStackDBContext dBContext)
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
