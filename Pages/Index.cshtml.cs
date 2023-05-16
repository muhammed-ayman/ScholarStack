using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Models;

namespace ScholarStack.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DB_Manager _db;
	public string[] usernames = new string[] { "Mohz", "Oppikn", "KingH" };
    public string username = "Mohz";

	public IndexModel(ILogger<IndexModel> logger, DB_Manager db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult OnGetPartial() =>
        Partial("_community-post");

    public void OnGet()
    {

    }
}
