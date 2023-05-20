using ScholarStack.Data;
using ScholarStack.Models;
using System.Linq;

namespace ScholarStack.Services
{
    public class VoteService
    {
        private readonly ScholarStackDBContext _dbContext;

        public VoteService(ScholarStackDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Upvote(int userId, int communityPostId)
        {
            // Check if the user has already upvoted the post
            var existingUpvote = _dbContext.Vote.FirstOrDefault(v => v.UserID == userId && v.CommunityPostID == communityPostId && v.VoteType == true);
            if (existingUpvote != null)
            {
                return false; // User has already upvoted the post
            }

            // Check if the user has previously downvoted the post
            var existingDownvote = _dbContext.Vote.FirstOrDefault(v => v.UserID == userId && v.CommunityPostID == communityPostId && v.VoteType == false);
            if (existingDownvote != null)
            {
                _dbContext.Vote.Remove(existingDownvote); // Remove the downvote
            }

            // Perform the upvote logic
            var upvote = new Vote
            {
                UserID = userId,
                CommunityPostID = communityPostId,
                VoteType = true
            };

            _dbContext.Vote.Add(upvote);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Downvote(int userId, int communityPostId)
        {
            // Check if the user has already downvoted the post
            var existingDownvote = _dbContext.Vote.FirstOrDefault(v => v.UserID == userId && v.CommunityPostID == communityPostId && v.VoteType == false);
            if (existingDownvote != null)
            {
                return false; // User has already downvoted the post
            }

            // Check if the user has previously upvoted the post
            var existingUpvote = _dbContext.Vote.FirstOrDefault(v => v.UserID == userId && v.CommunityPostID == communityPostId && v.VoteType == true);
            if (existingUpvote != null)
            {
                _dbContext.Vote.Remove(existingUpvote); // Remove the upvote
            }

            // Perform the downvote logic
            var downvote = new Vote
            {
                UserID = userId,
                CommunityPostID = communityPostId,
                VoteType = false
            };

            _dbContext.Vote.Add(downvote);
            _dbContext.SaveChanges();

            return true;
        }
    }
}