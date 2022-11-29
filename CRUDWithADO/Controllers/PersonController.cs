using CRUDWithADO.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CRUDWithADO.Controllers
{
    public class PersonController : Controller
    {
        private readonly IConfiguration configuration;
        PersonDAL personDAL;
        public PersonController(IConfiguration configuration)
        {
            this.configuration = configuration;
            personDAL = new PersonDAL(this.configuration);
        }
        // GET: PersonController
        public IActionResult List()
        {
            ViewBag.PersonList = personDAL.GetAllPersons();
            return View();
        }

        // GET: PersonController/Details/5
        public IActionResult Details(int id)
        {
            var model = personDAL.GetPersonById(id);
            return View(model);

        }

        // GET: PersonController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            try
            {
                int result = personDAL.AddPerson(person);
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

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = personDAL.GetPersonById(id);
            return View(model);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            try
            {
                int result = personDAL.UpdatePerson(person);
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

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = personDAL.GetPersonById(id);
            return View(model);

        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = personDAL.DeletePerson(id);
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
