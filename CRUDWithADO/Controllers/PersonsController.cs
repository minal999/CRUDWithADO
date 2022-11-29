using CRUDWithADO.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithADO.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IConfiguration configuration;
        PersonDAL personDAL;
        public PersonsController(IConfiguration configuration)
        {
            this.configuration = configuration;
            personDAL = new PersonDAL(this.configuration);
        }
        // GET: PersonsController
        public IActionResult List()
        {
            var model= personDAL.GetAllPersons();
            return View(model);
        }

        // GET: PersonsController/Details/5
        public IActionResult Details(int id)
        {
            var model = personDAL.GetPersonById(id);
            return View(model);

        }

        // GET: PersonsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonsController/Create
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

        // GET: PersonsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = personDAL.GetPersonById(id);
            return View(model);
        }

        // POST: PersonsController/Edit/5
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

        // GET: PersonsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = personDAL.GetPersonById(id);
            return View(model);

        }

        // POST: PersonsController/Delete/5
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
