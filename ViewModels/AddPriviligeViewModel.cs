using System.ComponentModel.DataAnnotations;

namespace ScholarStack.ViewModels
{
    public class AddPriviligeViewModel
    {

		[Required(ErrorMessage = "Cannot add an empty privilege!"), MinLength(3)]
		public string privilege_name { get; set; }
	}
}