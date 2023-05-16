using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;

namespace ScholarStack.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var email = value.ToString();

                // Get the DbContext instance from the ValidationContext
                var dbContext = (ScholarStackDBContext)validationContext.GetService(typeof(ScholarStackDBContext));

                // Check if any user with the same email already exists
                bool isEmailExists = dbContext.User.Any(u => u.Email == email);

                if (isEmailExists)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}