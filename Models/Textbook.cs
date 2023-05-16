using System.ComponentModel.DataAnnotations.Schema;
namespace ScholarStack.Models
{
	public class Textbook
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("publisher")]
		public string Publisher{ get; set; }

		[Column("resource_id")]
		public int ResourceID{ get; set; }
	}
}
