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
    public class UserManagementController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ScholarStackDBContext _dbContext;
        private readonly UserService _userService;

        public UserManagementController(IHttpContextAccessor httpContextAccessor, ScholarStackDBContext dbContext, UserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _userService = userService;
        }

        [HttpPost("delete-user")]
        public IActionResult deleteUser()
        {
            // Get the logged-in user ID from session
            var userIdString = HttpContext.Session.GetString("UserId");
            if (!int.TryParse(userIdString, out int userId))
            {
                // Unable to parse the user ID, return an unauthorized response
                return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
            }

            int user_id;
            if (!int.TryParse(Request.Form["user_id"], out user_id))
            {
				return BadRequest(new { message = "Invalid User." });
			}
			
            bool isDeleted = _userService.Delete(user_id);
            if (isDeleted)
            {
                return Ok(new { message = "Deletion successful" });
            }
            else
            {
                return BadRequest(new { message = "Unable to delete user." });
            }
		}

		[HttpPost("ban-user")]
		public IActionResult banUser()
		{
			// Get the logged-in user ID from session
			var userIdString = HttpContext.Session.GetString("UserId");
			if (!int.TryParse(userIdString, out int userId))
			{
				// Unable to parse the user ID, return an unauthorized response
				return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
			}

			int user_id;
			if (!int.TryParse(Request.Form["user_id"], out user_id))
			{
				return BadRequest(new { message = "Invalid User." });
			}

			bool isBanned = _userService.Ban(user_id);
			if (isBanned)
			{
				return Ok(new { message = "Ban successful" });
			}
			else
			{
				return BadRequest(new { message = "Unable to ban user." });
			}
		}

		[HttpPost("activate-user")]
		public IActionResult activateUser()
		{
			// Get the logged-in user ID from session
			var userIdString = HttpContext.Session.GetString("UserId");
			if (!int.TryParse(userIdString, out int userId))
			{
				// Unable to parse the user ID, return an unauthorized response
				return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
			}

			int user_id;
			if (!int.TryParse(Request.Form["user_id"], out user_id))
			{
				return BadRequest(new { message = "Invalid User." });
			}

			bool isActivated = _userService.Activate(user_id);
			if (isActivated)
			{
				return Ok(new { message = "Activation successful" });
			}
			else
			{
				return BadRequest(new { message = "Unable to activate user." });
			}
		}

	}
}