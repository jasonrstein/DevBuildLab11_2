using DevBuild11_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Dapper.Contrib.Extensions;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using DevBuild11_2.Models;
using Nest;
using Product = DevBuild11_2.Models.Product;

namespace DevBuild11_2.Controllers
{
    public class HomeController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server = localhost; Database = magicdetails; Uid = root; Password = abc123");
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int d)
        {
            List<Product> cats = db.GetAll<Product>().ToList();
            return View(cats);
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult RegistrationConfirmed(User user)
        {
            if (user.password.Length < 8)
            {
                return Content("Password is not long enough");
            }

            return View(user);
        }

        public IActionResult Products(int id)
        {
            
            Product cat = db.Get<Product>(id);
            return View(cat);
        }

        public IActionResult Editproduct (int id)
        {
            Product cat = db.Get<Product>(id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult edit(Product prod)
        {
            db.Update(prod);
            return RedirectToAction("Index");
        }

        public IActionResult CreateForm(Product prod)
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Product prod)
        {
            db.Insert(prod);
            return RedirectToAction("Index");
        }

        public IActionResult delete(int id)
        {
            Product prod = db.Get<Product>(id);
            db.Delete(prod);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
