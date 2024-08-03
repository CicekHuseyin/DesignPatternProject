using Microsoft.EntityFrameworkCore;

namespace DesignPatternProject.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KR485FT\\SQLEXPRESS;initial catalog=DbDesignPatternProject;integrated security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
