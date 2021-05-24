using Microsoft.AspNetCore.Mvc;
using MVCDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegistrationForm()
        {
            User user = new User();

            return View(user);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult DisplayForm(User data)
        {
            if (data != null)
            {
                ViewBag.DefaultMessage = "Thank You " + data.Name;
                if (data.WillAttend == "Yes")
                {
                    ViewBag.Message = "Thank you for Accepting Invitation";
                }
                if (data.WillAttend == "No")
                {
                    ViewBag.Message = "Try for the next session ";
                }
            }
            // ViewBag.message = "Thank you " + Username  ;
            return View();
        }
    }
}
