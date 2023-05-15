namespace ScholarStack.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
	public class User
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "First Name is Required"), MinLength(2), MaxLength(100)]
		public string FirstName { get; set; }

		[Required (ErrorMessage = "Last Name is Required"), MinLength(2), MaxLength(100)]
		public string LastName { get; set; }

		[Required (ErrorMessage = "Email is Required"), EmailAddress]
		public string Email { get; set; }

		[Required (ErrorMessage = "Password is Required"), PasswordPropertyText]
		public string Password { get; set; }

		[Required (ErrorMessage = "Username is Required"), MinLength(5), MaxLength(100)]
		public string UserName { get; set; }

		[Required (ErrorMessage = "Google Scholar Profile URL is Required"), Url]
		public string GoogleScholarURL { get; set; }

	}

