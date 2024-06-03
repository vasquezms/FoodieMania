
using FoodieMania.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FoodieMania.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Foodie>().HasIndex(c => c.Name).IsUnique();
        }

        #region DbSets
        public DbSet<Foodie> Foodies { get; set; }

        #endregion
    }
}

