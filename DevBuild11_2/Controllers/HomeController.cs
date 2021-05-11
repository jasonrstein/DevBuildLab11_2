using DevBuild11_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuild11_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult RegistrationConfirmed(string lastname, string firstname, string password, string email, string gender, string prefix)
        {
            if (password.Length < 8)
            {
                return Content("Password is not long enough");
            }

            ViewData["FirstName"] = firstname;
            ViewData["LastName"] = lastname;
            ViewData["email"] = email;
            ViewData["gender"] = gender;
            ViewData["Prefix"] = prefix;
            return Content($"Thank you {prefix}{firstname} {lastname} for registering. "
                           + $"We have your gender listed as {gender}.\n"
                           + "You will be contacted my a ninja assasin with future details.\n"
                           + "If the assassin does not kill you, then you have made it to the second round interview.");
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
