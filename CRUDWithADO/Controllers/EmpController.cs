using CRUDWithADO.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace CRUDWithADO.Controllers
{
    public class EmpController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeeDAL;
        public EmpController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeeDAL = new EmployeeDAL(this.configuration);
        }
        // GET: EmpController
        public ActionResult List()
        {
            ViewBag.EmployeeList = employeeDAL.GetAllEmployees();
            return View();
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                int result = employeeDAL.AddEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET: EmpController/Edit/5
        public IActionResult Edit(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);

        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeeDAL.UpdateEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET: EmpController/Delete/5
        public IActionResult Delete(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);

        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = employeeDAL.DeleteEmployee(id);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
