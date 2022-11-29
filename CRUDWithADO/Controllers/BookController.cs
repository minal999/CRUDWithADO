using CRUDWithADO.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithADO.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration configuration;
        BookDAL bookDAL;
        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            bookDAL = new BookDAL(this.configuration);
        }
        // GET: BookController
        public IActionResult List()
        {
            var model = bookDAL.GetAllBooks();
            return View(model);
        }

        // GET: BookController/Details/5
        public IActionResult Details(int id)
        {
            var model = bookDAL.GetBookById(id);
            return View(model);

        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            try
            {
                int result = bookDAL.AddBook(book);
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = bookDAL.GetBookById(id);
            return View(model);
        }

        // POST: PersonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = bookDAL.UpdateBook(book);
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = bookDAL.GetBookById(id);
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
                int result = bookDAL.DeleteBook(id);
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
