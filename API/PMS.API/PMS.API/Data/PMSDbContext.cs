using Microsoft.EntityFrameworkCore;
using PMS.API.Models.Domains;

namespace PMS.API.Data
{
    public class PMSDbContext:DbContext
    {
        public PMSDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
