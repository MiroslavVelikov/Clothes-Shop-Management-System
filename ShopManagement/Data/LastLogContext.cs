namespace Data
{
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Creating LastLog Database Context
    /// </summary>
    public class LastLogContext : DbContext
    {
        /// <summary>
        /// LastLog Table
        /// </summary>
        public DbSet<LastLog> LastLog { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LastLogContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Connection string to Microsoft SQL Server
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=lastLog; Integrated Security=True");
        }
    }
}
