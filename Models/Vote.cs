using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	[Table("Vote")]
    public class Vote
    {
		[Key]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserID { get; set; }

		[Key]
        [Column("community_post_id")]
        [ForeignKey("CommunityPost")]
        public int CommunityPostID { get; set; }

        [Column("vote_type")]
        public bool VoteType { get; set; }

        // Navigation properties
        public User User { get; set; }
        public CommunityPost CommunityPost { get; set; }
    }
}