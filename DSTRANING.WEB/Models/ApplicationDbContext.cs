using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DSTRANING.WEB.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer<ApplicationDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}