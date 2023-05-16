using System.ComponentModel.DataAnnotations.Schema;
namespace ScholarStack.Models
{
	public class ResourcePostComment
	{
		[Column("comment_id")]
		public int CommentID { get; set; }

		[Column("user_id")]
		public int UserID { get; set; }

		[Column("resource_post_id")]
		public int ResourcePostID { get; set; }
	}
}
