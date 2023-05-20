using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
    public class CommunityPost
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeStamp { get; set; }

        [Column("creator_id")]
        public int CreatorID { get; set; }

        [ForeignKey("CreatorID")]
        public User User { get; set; }

        public CommunityPostAttachment? Attachment { get; set; }

        // Navigation property for votes
        public List<Vote> Votes { get; set; } = new List<Vote>();

        // Navigation property for comments
        public List<CommunityPostComment> Comments { get; set; } = new List<CommunityPostComment>();

        [NotMapped]
        public double Score { get; set; }
    }
}