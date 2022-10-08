using Employee.DbModel;
using Employee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Common
{
    public class DropdownList
    {
        private readonly EmployeeContext db;

        public DropdownList(EmployeeContext _db)
        {
            db = _db;
        }
        public List<Departments> DepDdl()
        {
            List<Departments> lst = new List<Departments>();
            try
            {
                List<Departments> dep = db.Department_Info.Where(w => w.Is_Active == "1")
                    //.Select(s => new
                    //{
                    //    Dep_Id = s.Dep_Id,
                    //    Dep_Name = s.Dep_Name
                    //})
                    .ToList();
                dep.Insert(0, new Departments { Dep_Id = 0, Dep_Name = "Choose Department" });

                return dep;
            }
            catch (Exception e)
            {
                return lst;

            }
        }
    }
}
