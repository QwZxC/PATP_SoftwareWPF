using Microsoft.EntityFrameworkCore;

namespace PAPT_SoftwareWPF.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employment> Employments { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../../PATP_SoftwareDB.db");
        }
    }
}
