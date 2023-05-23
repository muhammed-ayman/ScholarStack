using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Privilege
	{
		[Column("id")]
		public int ID { get; set; }

		[Required, Column("privilege_name")]
		public string Name { get; set; }
	}
}
