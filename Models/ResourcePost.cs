using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class ResourcePost
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("timestamp")]
		public DateTime TimeStamp { get; set; }

		[Column("resource_id")]
		public int ResourceID { get; set; }
	}
}
