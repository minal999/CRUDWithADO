using CRUDWithADO.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUDWithADO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeeDAL;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeeDAL = new EmployeeDAL(this.configuration);
        }

        // GET: EmployeeController
        public IActionResult Index()
        {
            ViewBag.EmployeeList = employeeDAL.GetAllEmployees();
            return View();
        }

        // GET: EmployeeController/Details/5
        public IActionResult Details(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);

        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                int result = employeeDAL.AddEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET: EmployeeController/Edit/5
        public IActionResult Edit(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeeDAL.UpdateEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET: EmployeeController/Delete/5
        public IActionResult Delete(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);

        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = employeeDAL.DeleteEmployee(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
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
