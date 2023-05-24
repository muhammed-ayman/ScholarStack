using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;
using ScholarStack.Services;

namespace ScholarStack.Controllers
{
    [ApiController]
    [Route("api/community-post")]
    public class CommunityPostController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ScholarStackDBContext _dbContext;
        private readonly VoteService _voteService;

        public CommunityPostController(IHttpContextAccessor httpContextAccessor, ScholarStackDBContext dbContext, VoteService voteService)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _voteService = voteService;
        }

        [HttpPost("upvote")]
        public IActionResult Upvote()
        {
            // Get the logged-in user ID from session
            var userIdString = HttpContext.Session.GetString("UserId");
            if (!int.TryParse(userIdString, out int userId))
            {
                // Unable to parse the user ID, return an unauthorized response
                return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
            }

            int communityPostId;
            if (!int.TryParse(Request.Form["community_post_id"], out communityPostId))
            {
                // Unable to parse the community_post_id, return an error or appropriate response
                return BadRequest(new { message = "Invalid community_post_id." });
            }

            // Perform the upvote
            bool isUpvoted = _voteService.Upvote(userId, communityPostId);
            if (isUpvoted)
            {
                return Ok(new { message = "Upvote successful" });
            }
            else
            {
                return BadRequest(new { message = "You have already upvoted this post." });
            }
        }

        [HttpPost("downvote")]
        public IActionResult Downvote()
        {
            // Get the logged-in user ID from session
            var userIdString = HttpContext.Session.GetString("UserId");
            if (!int.TryParse(userIdString, out int userId))
            {
                // Unable to parse the user ID, return an error or appropriate response
                return BadRequest(new { message = "Invalid user ID." });
            }

            int communityPostId;
            if (!int.TryParse(Request.Form["community_post_id"], out communityPostId))
            {
                // Unable to parse the community_post_id, return an error or appropriate response
                return BadRequest(new { message = "Invalid community_post_id." });
            }

            // Perform the downvote
            bool isDownvoted = _voteService.Downvote(userId, communityPostId);
            if (isDownvoted)
            {
                return Ok(new { message = "Downvote successful" });
            }
            else
            {
                return BadRequest(new { message = "You have already downvoted this post." });
            }
        }

        [HttpGet("{postId}/votes")]
        public IActionResult GetVotes(int postId)
        {
            // Check if the user is logged in
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                // User is not logged in, return an unauthorized response
                return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
            }

            // Retrieve the community post from the database
            var communityPost = _dbContext.CommunityPost
                .Include(p => p.Votes)
                .FirstOrDefault(p => p.ID == postId);

            if (communityPost == null)
            {
                // Community post not found, return an appropriate response
                return NotFound(new { message = "Community post not found." });
            }

            int upvotes = communityPost.Votes.Count(v => v.VoteType == true);
            int downvotes = communityPost.Votes.Count(v => v.VoteType == false);

            var response = new
            {
                upvotes = upvotes,
                downvotes = downvotes
            };

            return Ok(response);
        }

        [HttpPost("{postId}/add-comment")]
        public IActionResult AddComment(int postId)
        {
            // Get the logged-in user ID from session
            var userIdString = HttpContext.Session.GetString("UserId");
            if (!int.TryParse(userIdString, out int userId))
            {
                // Unable to parse the user ID, return an unauthorized response
                return Unauthorized(new { message = "Unauthorized: You're not authorized to access this endpoint!" });
            }

            // Retrieve the logged-in user from the database
            var user = _dbContext.User.Find(userId);
            if (user == null)
            {
                // User not found, return an appropriate response
                return NotFound(new { message = "User not found." });
            }

            // Retrieve the community post from the database
            var communityPost = _dbContext.CommunityPost.Find(postId);

            if (communityPost == null)
            {
                // Community post not found, return an appropriate response
                return NotFound(new { message = "Community post not found." });
            }

            string commentText = Request.Form["comment_text"];

            // Create a new comment
            var comment = new Comment
            {
                Content = commentText,
                TimeStamp = DateTime.Now
            };

            // Save the comment to the database
            _dbContext.Comment.Add(comment);
            _dbContext.SaveChanges();

            // Create a new community post comment entry
            var communityPostComment = new CommunityPostComment
            {
                UserID = userId,
                CommunityPostID = postId,
                Comment = comment
            };

            // Save the community post comment to the database
            _dbContext.CommunityPostComment.Add(communityPostComment);
            _dbContext.SaveChanges();

            // Optionally, you can return the newly created comment as a response
            return Ok(new { message = "Comment added successfully", comment, user });
        }

    }
}