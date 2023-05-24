using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;
using ScholarStack.Services;

namespace ScholarStack.Controllers
{
	[ApiController]
	[Route("api/dashboard")]
	public class PrivilegeManagementController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ScholarStackDBContext _dbContext;
		private readonly PrivilegeService _privilegeService;

		public PrivilegeManagementController(IHttpContextAccessor httpContextAccessor, ScholarStackDBContext dbContext, PrivilegeService privilegeService)
		{
			_httpContextAccessor = httpContextAccessor;
			_dbContext = dbContext;
			_privilegeService = privilegeService;
		}

		[HttpPost("delete-privilege")]
		public IActionResult deletePrivilege()
		{
			// Get the logged-in user ID from session
			var userIdString = HttpContext.Session.GetString("UserId");
			if (!int.TryParse(userIdString, out int userId))
			{
				// Unable to parse the user ID, return an unauthorized response
				return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
			}

			int privilege_id;
			if (!int.TryParse(Request.Form["privilege_id"], out privilege_id))
			{
				return BadRequest(new { message = "Invalid Privilege." });
			}

			bool isDeleted = _privilegeService.Delete(privilege_id);
			if (isDeleted)
			{
				return Ok(new { message = "Deletion successful" });
			}
			else
			{
				return BadRequest(new { message = "Unable to delete privilege." });
			}
		}
	}
}