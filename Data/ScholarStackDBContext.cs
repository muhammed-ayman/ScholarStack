using Microsoft.EntityFrameworkCore;
using ScholarStack.Models;

namespace ScholarStack.Data
{
    public class ScholarStackDBContext : DbContext
    {
        public ScholarStackDBContext(DbContextOptions<ScholarStackDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
		public DbSet<CommunityPost> CommunityPost { get; set; }
		public DbSet<ResourcePost> ResourcePost { get; set; }
		public DbSet<CommunityPostAttachment> CommunityPostAttachment { get; set; }
		// public DbSet<CommunityPostComment> CommunityPostComment { get; set; }
	}
}
