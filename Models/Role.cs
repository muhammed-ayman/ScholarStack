using System.ComponentModel.DataAnnotations.Schema;
namespace ScholarStack.Models
{
	public class Role
	{
		[Column("id")]
		public int ID{ get; set; }

		[Column("role_name")]
		public string Name { get; set; }
	}
}
