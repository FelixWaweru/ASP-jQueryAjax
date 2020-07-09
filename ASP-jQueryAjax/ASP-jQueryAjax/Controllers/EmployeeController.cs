using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_jQueryAjax.Models;

namespace ASP_jQueryAjax.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllEmployees());
        }

        IEnumerable<Employee> GetAllEmployees()
        {
            using (DBModel db = new DBModel())
            {
                return db.Employees.ToList<Employee>();
            }
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Employee emp = new Employee();
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            if(emp.ImageUpload!= null)
            {
                string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                string extension = Path.GetExtension(emp.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("77mmssfff") + extension;
                emp.ImagePath = "~/AppFiles/Images/" + fileName;
                emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
            }

            using (DBModel db = new DBModel())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }
                return RedirectToAction("ViewAll");
        }
    }
}