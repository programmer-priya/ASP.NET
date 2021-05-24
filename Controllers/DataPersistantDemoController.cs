using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCDemoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVCDemoApp.Controllers
{
    public class DataPersistantDemoController : Controller
    {
        public IConfiguration Configuration { get; }
        public DataPersistantDemoController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            ViewBag.data = Configuration["CustomKey"];
            return View();

        }

        public IActionResult SessionDemo()
        {
            //create session values
            HttpContext.Session.SetString("message", "Session test");
            HttpContext.Session.SetInt32("count", 5);
            HttpContext.Session.SetString("dateobj", JsonSerializer.Serialize(DateTime.Now));
            //Employee employee = new Employee { EmpId = 100, EmpName = "Priyanka", Salary = 30000 };
            //string empserializedata = JsonSerializer.Serialize(employee);
            //HttpContext.Session.SetString("empobj", empserializedata);
            return RedirectToAction("GetSessionValues");
        }

        public IActionResult GetSessionValues()
        {
            ViewBag.message = HttpContext.Session.GetString("message");
            ViewBag.count = HttpContext.Session.GetInt32("count");

            var dateobj = HttpContext.Session.GetString("dateobj");
            //ViewBag.date = JsonSerializer.Deserialize<DateTime>(dateobj);

            //string emp = HttpContext.Session.GetString("empobj");
            //Employee.empobj = JsonSerializer.Deserialize<Employee>(emp);
            //ViewBag.emp = empobj;


            return View();
        }
        public IActionResult WriteCookies(string setting, string settingValues, bool isPersistent)
        {
            if (isPersistent)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(setting, settingValues, options);
            }
            else
            {
                Response.Cookies.Append(setting, settingValues);
            }
            ViewBag.Message = "Cookie written successfully!";
            
            return View("Index");
        }

        public IActionResult ReadCookies()
        {
            ViewBag.FontName = Request.Cookies["fontName"];
            ViewBag.FontSize = Request.Cookies["fontsize"];
            ViewBag.Color = Request.Cookies["color"];
            if (string.IsNullOrEmpty(ViewBag.FontName))
            {
                ViewBag.FontName = "Arial";
            }
            if (string.IsNullOrEmpty(ViewBag.FontSize))
            {
                ViewBag.FontName = "22px";
            }
            if (string.IsNullOrEmpty(ViewBag.Color))
            {
                ViewBag.FontName = "Black";
            }



            return View();
        }
    }
}
