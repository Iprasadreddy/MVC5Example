using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCController.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View("Sample");
        }
        public ContentResult GetEmpName(int id)
        {
            //Anonymous Types
            var employees = new[]
            {
                new {empID=101,EmpName="Srikanth",Salary=12345},
                new {empID=102,EmpName="Ravi",Salary=2345},
                new {empID=103,EmpName="SUbbu",Salary=62345},
                new {empID=104,EmpName="Sai",Salary=76345}
            };
            string empName = string.Empty;
            foreach (var item in employees) 
            {
                if(item.empID == id)
                {
                    empName = item.EmpName;
                }
            }
            if(!string.IsNullOrEmpty(empName)) 
            {
                return Content(empName);
            }
            else
            {
                return Content("No Employee Found");
            }
        }
        public FileResult GetFile(int id) 
        {
            string fileName = "~Images/image" + id + ".jpg";
            return File(fileName,"image/jpg");
        }
        public RedirectResult GotoGoogle()
        {
            return Redirect("http://www.google.com");
        }

        public ActionResult GetStudentResult()
        {
            double[] marks = { 63, 96, 45, 85, 23, 74 };
            bool result = StudentResult(marks);
            if(result == true)
            {
                return Content("Student Pass");
            }
            else
            {
                return Content("Student Failed");
            }
            
        }
        [NonAction]
        public bool StudentResult(double[] marks)
        {
            foreach(var item in marks)
            {
                if(item < 35)
                {
                    return false;
                }
            }
            return true;
        }
        public ActionResult GetProductName(int id)
        {
            var products = new[]
            {
                new {ID=1,Name="Mobile"},
                new {ID=2,Name="Laptop"},
                new {ID=3,Name="Desktop"},
                new {ID=4,Name="XBox"},
            };
            var isAvailable = products.Where(x=>x.ID==id).FirstOrDefault().Name;
            if (!string.IsNullOrWhiteSpace(isAvailable))
                return RedirectToAction("Index");
            else
                return Content("Product is Not Available");
        }
    }
}