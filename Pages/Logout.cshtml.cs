using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using ScholarStack.Data;

namespace ScholarStack.Pages
{
    public class LogoutModel : PageModel
    {
        public LogoutModel(ILogger<LogoutModel> logger) {}

        public IActionResult OnGet()
        {
            // Clear all session data
            HttpContext.Session.Clear();

            // Redirect or perform other actions as needed
            return RedirectToAction("Index");
        }
    }
}
