using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;

namespace ScholarStack.Attributes
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var username = value.ToString();

                // Get the DbContext instance from the ValidationContext
                var dbContext = (ScholarStackDBContext)validationContext.GetService(typeof(ScholarStackDBContext));

                // Check if any user with the same email already exists
                bool isUsernameExists = dbContext.User.Any(u => u.Username == username);

                if (isUsernameExists)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}