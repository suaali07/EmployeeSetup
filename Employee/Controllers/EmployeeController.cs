
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Employee.Repository;
using Employee.Model;
using Employee.Common;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        RP_Employee emp;
        DropdownList ddl;
        public EmployeeController(RP_Employee _emp, DropdownList _ddl)
        {
            emp = _emp;
            ddl = _ddl;
        }
        public IActionResult EmployeeList()
        {
            string err;
            try
            {
                var empDt = emp.GetEmployees();

                return View(empDt);
            }
            catch (Exception e)
            {
                err = e.Message;
                return View();
            }

        }
        public IActionResult Create(EmployeeDetail emp)
        {
            DepDdl();
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDetail empDt)
        {
            string err;
            try
            {
                if(ModelState.IsValid)
                {
                    string ret = emp.AddEmployee(empDt);
                    if (ret == "OK")
                        return RedirectToAction("EmployeeList");
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return RedirectToAction("EmployeeList");
            }
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> DeleteEmp(EmployeeDetail empId)
        {
            string ret;
            try
            {
                empId.Is_Active = "0";
                ret = emp.AddEmployee(empId);

                return RedirectToAction("EmployeeList");
            }
            catch (Exception e)
            {

                return RedirectToAction("EmployeeList");
            }
        }

        #region DropDown List
        public void DepDdl()
        {
            ViewBag.DepDdl = ddl.DepDdl();
        }
        #endregion
    }
}
