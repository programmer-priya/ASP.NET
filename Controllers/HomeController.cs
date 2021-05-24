using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Controllers
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
        [Route("Home/Greet/{name?}")]
        public IActionResult Greet(string name)
        {
            //return Content("Welcome to MVC");
            ViewBag.wish = "Hello  " + name;
            return View();
        }
        [Route("[controller]/[action]/{num1:int:range(1,100)}/{num2:int}")]
        public IActionResult GetData(int num1, int num2)
        {
            ViewBag.message = "Addition is :  = " + (num1 + num2);
            return View();
        }

        public IActionResult ModelDemo()
        {
            Employee employee = new Employee { EmpId = 100, EmpName = "Priyanka", Salary = 30000 };
            // ViewBag.emp = employee;
            ViewData["emp"] = employee;
            return View();
        }

        public IActionResult EmployeeForm()
        {
            return View(new Employee());
        }

        public IActionResult DisplayEmployeeData(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return View(employee);
            }

            return View("EmployeeFrom", employee);
        }

       // public IActionResult HTMLHelper


      
    }
}
