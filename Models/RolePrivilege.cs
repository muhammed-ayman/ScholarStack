using System.ComponentModel.DataAnnotations.Schema;
namespace ScholarStack.Models
{
	public class RolePrivilege
	{
		[Column("role_id")]
		public int RoleID { get; set; }
		
		[Column("privilege_id")]
		public int PrivilegeID { get; set; }
	}
}
