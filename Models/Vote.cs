using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
    [Table("Vote")]
    public class Vote
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("user_id")]
        public int UserID { get; set; }

        [Column("community_post_id")]
        public int CommunityPostID { get; set; }

        [Column("vote_type")]
        public bool VoteType { get; set; }

        // Navigation properties
        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("CommunityPostID")]
        public CommunityPost CommunityPost { get; set; }
    }
}