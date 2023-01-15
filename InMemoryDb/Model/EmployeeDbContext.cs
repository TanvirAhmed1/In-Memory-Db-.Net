using Microsoft.EntityFrameworkCore;

namespace InMemoryDb.Model
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
