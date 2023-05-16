using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class CommunityPostComment
	{
		[Column("comment_id")]
		public int CommentID { get; set; }

		[Column("user_id")]
		public int UserID { get; set; }

		[Column("community_post_id")]
		public int CommunityPostID { get; set; }
	}
}
