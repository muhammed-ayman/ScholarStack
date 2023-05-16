using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Rating
	{
		[Column("resource_id")]
		public int ResourceID { get; set; }

		[Column("user_id")]
		public int UserID { get; set; }

		[Column("value")]
		public int Value { get; set; }
	}
}
