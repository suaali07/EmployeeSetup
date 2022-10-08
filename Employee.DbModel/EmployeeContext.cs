
using Employee.Model;
using Microsoft.EntityFrameworkCore;


namespace Employee.DbModel
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<EmployeeDetail> Employee_Detail { get; set; }
        public DbSet<Departments> Department_Info { get; set; }
    }
}
