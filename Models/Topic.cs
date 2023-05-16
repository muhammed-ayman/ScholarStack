using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Topic
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("name")]
		public string Name { get; set; }
	}
}
