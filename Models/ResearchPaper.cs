using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class ResearchPaper
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("doi")]
		public string DOI { get; set; }

		[Column("citations")]
		public int Citations { get; set; }

		[Column("resource_id")]
		public int ResourceID { get; set; }
	}
}
