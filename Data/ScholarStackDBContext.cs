using Microsoft.EntityFrameworkCore;
using ScholarStack.Models;

namespace ScholarStack.Data
{
    public class ScholarStackDBContext : DbContext
    {
        public ScholarStackDBContext(DbContextOptions<ScholarStackDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                .HasKey(v => new { v.UserID, v.CommunityPostID });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
		public DbSet<CommunityPost> CommunityPost { get; set; }
		public DbSet<Vote> Vote { get; set; }
		public DbSet<Comment> Comment { get; set; }
		public DbSet<ResourcePost> ResourcePost { get; set; }
		public DbSet<CommunityPostAttachment> CommunityPostAttachment { get; set; }
		public DbSet<Privilege> Privilege { get; set; }
		public DbSet<CommunityPostComment> CommunityPostComment { get; set; }
	}
}
