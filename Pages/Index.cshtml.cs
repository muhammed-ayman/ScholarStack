using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Models;

namespace ScholarStack.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DB_Manager _db;

    public IndexModel(ILogger<IndexModel> logger, DB_Manager db)
    {
        _logger = logger;
        _db = db;
    }

    public void OnGet()
    {

    }
}
