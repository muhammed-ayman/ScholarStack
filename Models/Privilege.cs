using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarStack.Models
{
	public class Privilege
	{
		[Column("id")]
		public int ID { get; set; }

		[Column("privilege_name")]
		public string privilege_name { get; set; }
	}
}
