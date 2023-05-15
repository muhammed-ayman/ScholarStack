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

		public void AddUser(User u){ // Function should add user to the database
			string query = "SELECT * FROM USER"; // Only an example
			FExecuteNonQuery(query);
		}

		public User UpdateUser(User u) // Function should update the info of user
			// It might be useful in the Edit Profile page
		{
			string query = "SELECT * FROM USER"; // Only an example
			FExecuteNonQuery(query);
			return u;
		}

		public void DeleteUser(User u) // Function should delete the user
			// It will be helpful for the admins
		{
			string query = "SELECT * FROM USER"; // Only an example
			FExecuteNonQuery(query);
		}

		private void FExecuteNonQuery(string q) // General function that executes any non query
			// That is, add, modify, and delete can all be made using this function
		{
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand(q, con);
				cmd.ExecuteNonQuery(); // Since it returns "n rows affected".
				con.Close();

			}
			catch (Exception ex)
			{
				con.Close();
				// To be edited
			}
		}
	}
}
