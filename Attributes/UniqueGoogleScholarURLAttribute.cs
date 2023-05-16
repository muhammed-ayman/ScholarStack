using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;

namespace ScholarStack.Attributes
{
    public class UniqueGoogleScholarURLAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var google_scholar_url = value.ToString();

                // Get the DbContext instance from the ValidationContext
                var dbContext = (ScholarStackDBContext)validationContext.GetService(typeof(ScholarStackDBContext));

                // Check if any user with the same email already exists
                bool isGoogleScholarURLExists = dbContext.User.Any(u => u.GoogleScholarURL == google_scholar_url);

                if (isGoogleScholarURLExists)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}