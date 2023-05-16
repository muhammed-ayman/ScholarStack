using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScholarStack.Pages
{
    public class ResourceFeedModel : PageModel
    {

		public IActionResult OnGetPartial() =>
	        Partial("_community-post");

		public void OnGet()
        {
        }
    }
}
