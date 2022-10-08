using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Employee.DbModel;
using Employee.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repository
{
    public class RP_Employee
    {
        private readonly EmployeeContext db;

        public RP_Employee(EmployeeContext _db)
        {
            db = _db;
        }

        public List<EmployeeDetail> GetEmployees()
        {
            List<EmployeeDetail> lst = new List<EmployeeDetail>();
            EmployeeDetail data = new EmployeeDetail();

            try
            {
                var emp = db.Employee_Detail.Join(db.Department_Info, a => a.Emp_Dep_Id, b => b.Dep_Id, (a, b) => new { a, b })
                    .Where(w => w.a.Is_Active == "1")
                    .Select(s => new
                    {
                        Emp_Id = Convert.ToDecimal(s.a.Emp_Id),
                        Emp_Name = s.a.Emp_Name,
                        Emp_Email = s.a.Emp_Email,
                        Emp_Description = s.a.Emp_Description,
                        Emp_Dep_Id = Convert.ToDecimal(s.a.Emp_Dep_Id),
                        Emp_Dep_Name = s.b.Dep_Name == null ? "" : s.b.Dep_Name
                    })
                    .ToList();

                //var emp = from a in db.Employee_Detail
                //          join b in db.Department_Info
                //              on a.Emp_Dep_Id equals b.Dep_Id
                //          into Dep
                //          from b in Dep.DefaultIfEmpty()
                //          where a.Is_Active == "1"
                //          select new EmployeeDetail
                //          {
                //              Emp_Id = Convert.ToDecimal(a.Emp_Id),
                //              Emp_Name = a.Emp_Name,
                //              Emp_Email = a.Emp_Email,
                //              Emp_Description = a.Emp_Description,
                //              Emp_Dep_Id = Convert.ToDecimal(a.Emp_Dep_Id),
                //              Emp_Dep_Name = b.Dep_Name == null ? "" : b.Dep_Name
                //          };

                foreach (var i in emp)
                {
                    data.Emp_Id = i.Emp_Id;
                    data.Emp_Name = i.Emp_Name;
                    data.Emp_Email = i.Emp_Email;
                    data.Emp_Description = i.Emp_Description;
                    data.Emp_Dep_Id = i.Emp_Dep_Id;
                    data.Emp_Dep_Name = i.Emp_Dep_Name == null ? "" : i.Emp_Dep_Name;

                    lst.Add(data);
                }
            }
            catch (Exception e)
            {
                lst.Add(data);
            }
            return lst;
        }

        public string AddEmployee(EmployeeDetail emp)
        {
            try
            {
                if (emp.Emp_Id == 0 || emp.Emp_Id == null)
                {
                    emp.Emp_Id = Convert.ToDecimal(db.Employee_Detail.Max(m => m.Emp_Id)) + 1;

                    db.Employee_Detail.Add(emp);
                }
                else if (emp.Emp_Id > 0)
                {
                    db.Entry(emp).State = EntityState.Modified;
                }
                db.SaveChangesAsync();
                return "OK";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
