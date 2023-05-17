using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;

namespace ScholarStack.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ScholarStackDBContext _dbContext;

	public List<CommunityPost> CommunityPosts { get; set; }

	public IndexModel(ILogger<IndexModel> logger, ScholarStackDBContext dBContext)
    {
        _logger = logger;
        _dbContext = dBContext;
    }

    public IActionResult OnGetPartial() =>
        Partial("_community-post");

    public void OnGet()
    {
        RetrievePosts();   
    }

	private void RetrievePosts()
	{
		CommunityPosts = _dbContext.CommunityPost
			.Include(p => p.User)
			.Include(p => p.Attachment)
			.Select(p => new CommunityPost
			{
				ID = p.ID,
				Content = p.Content,
				TimeStamp = p.TimeStamp,
				CreatorID = p.CreatorID,
				User = p.User,
				Attachment = p.Attachment
			})
			.ToList();
	}
}
