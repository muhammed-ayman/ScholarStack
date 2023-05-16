using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class ResourceTopic
	{
		[Column("resource_id")]
		public int ResourceID { get; set; }

		[Column("topic_id")]
		public int TopicID { get; set; }
	}
}
