namespace Data
{
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;
   
    /// <summary>
    /// Creating Product Database Context
    /// </summary>
    public class ClotheContext : DbContext
    {
        /// <summary>
        /// Clothes Table
        /// </summary>
        public DbSet<Clothe> Clothes { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClotheContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Connection string to Microsoft SQL Server
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=clothes; Integrated Security=True");
        }
    }
}
