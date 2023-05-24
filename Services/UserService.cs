using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;
using System.Linq;

namespace ScholarStack.Services
{
    public class UserService
    {
        private readonly ScholarStackDBContext _dbContext;

        public UserService(ScholarStackDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(int userId)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.ID == userId);

            if (user != null)
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return true;
			}
            else
            { 
                return false; 
            }
        }

		public bool Ban(int userId)
		{
			var user = _dbContext.User.FirstOrDefault(u => u.ID == userId);

			if (user != null)
			{
				user.Is_banned = true;
				_dbContext.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool Activate(int userId)
		{
			var user = _dbContext.User.FirstOrDefault(u => u.ID == userId);

			if (user != null)
			{
				user.Is_banned = false;
				_dbContext.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}