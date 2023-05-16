using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class CommunityPostAttachment
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("url")]
		public string URL { get; set; }

		[Column("community_post_id")]
		public int CommunityPostID { get; set; }
	}
}
