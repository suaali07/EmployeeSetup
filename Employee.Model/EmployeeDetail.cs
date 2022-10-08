
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class EmployeeDetail
    {
        [Key]
        public decimal? Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        [EmailAddress]
        public string Emp_Email { get; set; }
        public string Emp_Description { get; set; }
        public decimal? Emp_Dep_Id { get; set; }
        [NotMapped]
        public string? Emp_Dep_Name { get; set; }
        public string Is_Active { get; set; }
    }
}
