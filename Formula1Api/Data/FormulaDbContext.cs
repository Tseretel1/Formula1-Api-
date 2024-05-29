using Formula1Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1Api.Data
{
    public class FormulaDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Photo> Photos { get; set; }    
        public FormulaDbContext(DbContextOptions<FormulaDbContext> options) : base(options)
        {

        }
    }
}
