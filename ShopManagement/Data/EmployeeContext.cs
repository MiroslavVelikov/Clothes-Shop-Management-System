namespace Data
{
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Creating Employee Database Context
    /// </summary>
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// Employees Table
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Connection string to Microsoft SQL Server
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=employees; Integrated Security=True");
        }
    }
}
