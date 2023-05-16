using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Comment
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("content")]
		public string Content { get; set; }

		[Column("timestamp")]
		public DateTime TimeStamp { get; set; }
	}
}
