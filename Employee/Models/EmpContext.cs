using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {

        }

        public DbSet<EmployeeDetail> Employee_Detail { get; set; }
        public DbSet<Departments> Department_Info { get; set; }
    }
}
