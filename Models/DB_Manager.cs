using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScholarStack.Models
{
	public class DB_Manager
	{
		public SqlConnection con { get; set; }
		public DB_Manager() 
		{
			string conString = "Data Source = MOHZMAGDY; Initial Catalog = ScholarStack; Integrated Security = True";
			con = new SqlConnection(conString);
		}
	}
}
