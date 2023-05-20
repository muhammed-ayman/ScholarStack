using System.ComponentModel.DataAnnotations;

namespace ScholarStack.ViewModels
{
    public class CPostViewModel
    {
        [Required (ErrorMessage = "You can not create an empty post!")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public IFormFile PostImageAttachment { get; set; }
    }
}