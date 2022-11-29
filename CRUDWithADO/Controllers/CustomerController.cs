using CRUDWithADO.DAL;
using CRUDWithADO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;


namespace CRUDWithADO.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration configuration;
        CustomerDAL customerDAL;
        public CustomerController(IConfiguration configuration)
        {
            this.configuration = configuration;
            customerDAL = new CustomerDAL(this.configuration);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customer cust)
        {
            try
            {
                int result = customerDAL.CustomerRegister(cust);
                if(result==1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Customer cust)
        {
            Customer c = customerDAL.CustomerLogin(cust);
            if(c!=null)
            {
                return RedirectToAction("List", "Emp");
            }
            else
            {
                return View();
            }
            
        }
    }
}
