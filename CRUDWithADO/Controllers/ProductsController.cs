using CRUDWithADO.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithADO.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration configuration;
        ProductDAL productDAL;
        public ProductsController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productDAL = new ProductDAL(this.configuration);
        }
        // GET: ProductsController
        public IActionResult List()
        {
            var model = productDAL.GetAllProducts();
            return View(model);
        }

        // GET: ProductsController/Details/5
        public IActionResult Details(int id)
        {
            var model = productDAL.GetProductById(id);
            return View(model);

        }

        // GET: ProductsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                int result = productDAL.AddProduct(product);
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

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = productDAL.GetProductById(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = productDAL.UpdateProduct(product);
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

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = productDAL.GetProductById(id);
            return View(model);

        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = productDAL.DeleteProduct(id);
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
