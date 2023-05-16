using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class TopicKeyword
	{
		[Column("keyword_id")]
		public int KeywordID { get; set; }

		[Column("topic_id")]
		public int TopicID { get; set; }
	}
}
