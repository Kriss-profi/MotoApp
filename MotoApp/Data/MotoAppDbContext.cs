namespace MotoApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using MotoApp.Entities;
    public class MotoAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<BuisnessPartner> BuisnessPartners => Set<BuisnessPartner>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
