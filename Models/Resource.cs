using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Resource
	{
		[Column("id")]
		public int ID{ get; set; }

		[Column("hyper_link")]
		public string Hyperlink { get; set; }

		[Column("timestamp")]
		public DateTime TimeStamp { get; set; }
	}
}
