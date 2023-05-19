using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Data;
using ScholarStack.ViewModels;
using ScholarStack.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace ScholarStack.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly ScholarStackDBContext _dbContext;
        private readonly PasswordHasher<User> _passwordHasher;

        [BindProperty(Name = "loginViewModel")]
        public LoginViewModel? loginViewModel { get; set; }

        [BindProperty(Name = "registerViewModel")]
        public RegisterViewModel? registerViewModel { get; set; }

        public LoginModel(ScholarStackDBContext dbContext, ILogger<LoginModel> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _passwordHasher = new PasswordHasher<User>();
        }

        public void OnGet()
        {
        }

        [HttpPost]
        public IActionResult OnPostRegister()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(registerViewModel);

            // Manually perform validation
            bool isValid = Validator.TryValidateObject(registerViewModel, context, validationResults, true);

            if (!isValid)
            {
                return Page();
            }

            // Hash the password
            string passwordHash = HashPassword(registerViewModel.Password);

            User newUser = new User
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Password = passwordHash,
                Username = registerViewModel.Username,
                GoogleScholarURL = registerViewModel.GoogleScholarURL,
                UserRole = 1, // Ordinary user role
            };

            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();

            return RedirectToPage("Index");
        }

        [HttpPost]
        public IActionResult OnPostLogin()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(loginViewModel);

            // Manually perform validation
            bool isValid = Validator.TryValidateObject(loginViewModel, context, validationResults, true);

            if (!isValid)
            {
                return Page();
            }

            // Validate user credentials against the database
            var user = _dbContext.User.FirstOrDefault(u =>
                u.Username == loginViewModel.Username);

            if (user == null || !VerifyPassword(loginViewModel.Password, user.Password))
            {
                ModelState.AddModelError("InvalidLogin", $"Invalid username or password");
                return Page();
            }

            // Store user information in session
            HttpContext.Session.SetString("UserId", user.ID.ToString());
            HttpContext.Session.SetString("UserName", user.Username);

            return RedirectToPage("Index");
        }

        private string HashPassword(string password)
        {
            // Hash the password
            string hashedPassword = _passwordHasher.HashPassword(null, password);
            return hashedPassword;
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Verify the password
            var result = _passwordHasher.VerifyHashedPassword(null, passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}