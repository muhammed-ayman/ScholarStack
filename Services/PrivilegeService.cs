using Microsoft.EntityFrameworkCore;
using ScholarStack.Data;
using ScholarStack.Models;
using System.Linq;

namespace ScholarStack.Services
{
	public class PrivilegeService
	{
		private readonly ScholarStackDBContext _dbContext;

		public PrivilegeService(ScholarStackDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public bool Delete(int privId)
		{
			var privilege = _dbContext.Privilege.FirstOrDefault(p => p.ID == privId);

			if (privilege != null)
			{
				_dbContext.Remove(privilege);
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
