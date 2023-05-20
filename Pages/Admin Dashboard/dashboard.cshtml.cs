using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarStack.Data;
using ScholarStack.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScholarStack.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ScholarStackDBContext _dbContext;

        public DashboardStatistics Statistics { get; set; }

        public DashboardModel(ScholarStackDBContext dbContext)
        {
            _dbContext = dbContext;
            Statistics = new DashboardStatistics();
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _dbContext.User.Include(u => u.Role).ToList();
            CalculateDashboardStatistics();
        }

        private void CalculateDashboardStatistics()
        {
            CalculateRegisteredUsers();
            CalculateManagers();
            CalculateCommunityPostsCount();
            CalculateResourcePostsCount();
        }

        private void CalculateRegisteredUsers()
        {
            DateTime lastMonthDate = DateTime.Now.AddMonths(-1);
            Statistics.RegisteredUsers = _dbContext.User.Count();
        }

        private void CalculateManagers()
        {
            Statistics.ManagersCount = _dbContext.User.Count(u => u.UserRole == 2); // 2: default manager rule
        }

        private void CalculateCommunityPostsCount()
        {
            Statistics.CommunityPostsCount = _dbContext.CommunityPost.Count();
        }

        private void CalculateResourcePostsCount()
        {
            Statistics.ResourcePostsCount = _dbContext.ResourcePost.Count();
        }
    }

    public class DashboardStatistics
    {
        public int RegisteredUsers { get; set; }
        public int ManagersCount { get; set; }
        public int CommunityPostsCount { get; set; }
        public int ResourcePostsCount { get; set; }
    }
}
