using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class User
	{
		[Column("id")]
		public int ID { get; set; }

		[Required(ErrorMessage = "First Name is Required"), MinLength(2), MaxLength(100), Column("first_name")]
		public string FirstName { get; set; }

		[Required (ErrorMessage = "Last Name is Required"), MinLength(2), MaxLength(100), Column("last_name")]
		public string LastName { get; set; }

		[Required (ErrorMessage = "Email is Required"), EmailAddress, Column("email")]
		public string Email { get; set; }

		[Required (ErrorMessage = "Password is Required"), PasswordPropertyText, Column("password")]
		public string Password { get; set; }

		[Required (ErrorMessage = "Username is Required"), MinLength(5), MaxLength(100), Column("username")]
		public string Username { get; set; }

		[Required (ErrorMessage = "Google Scholar Profile URL is Required"), Url, Column("google_scholar_url")]
		public string GoogleScholarURL { get; set; }

		[Column("role")]
		public int UserRole { get; set; }

		[Column("profile_picture")]
		public string UserImage { get; set; }

	}
}