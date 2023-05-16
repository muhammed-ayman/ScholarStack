using Microsoft.EntityFrameworkCore;
using ScholarStack.Models;

namespace ScholarStack.Data
{
    public class ScholarStackDBContext : DbContext
    {
        public ScholarStackDBContext(DbContextOptions<ScholarStackDBContext> options) : base(options)
        {
            
        }
    }
}
