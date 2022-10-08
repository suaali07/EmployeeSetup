using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Departments
    {
        [Key]
        public decimal? Dep_Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Dep_Name { get; set; }
        public string Is_Active { get; set; }
    }
}
