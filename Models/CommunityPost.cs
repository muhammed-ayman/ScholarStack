using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

		// public ICollection<CommunityPostComment>? CommunityPostComments { get; set; }
	}
}