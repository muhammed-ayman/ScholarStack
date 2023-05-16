using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class ResearchInterest
	{
		[Column("user_id")]
		public int UserID { get; set; }

		[Column("topic_id")]
		public int TopicID { get; set; }
	}
}
