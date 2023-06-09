using System.ComponentModel.DataAnnotations;

namespace ScholarStack.ViewModels
{
    public class UpdateViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Google Scholar Profile URL is Required")]
        [Url]
        public string GoogleScholarURL { get; set; }
    }
}
