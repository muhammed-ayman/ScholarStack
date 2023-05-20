using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class CommunityPostComment
	{
		[Key]
		[Column("comment_id")]
		public int CommentID { get; set; }

		[Column("user_id")]
		public int UserID { get; set; }

		[Column("community_post_id")]
		public int CommunityPostID { get; set; }

		[ForeignKey("UserID")]
		public User User { get; set; }

		[ForeignKey("CommentID")]
		public Comment Comment { get; set; }
	}
}
