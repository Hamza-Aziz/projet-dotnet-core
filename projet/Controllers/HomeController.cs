using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projet.Models;
namespace projet.Controllers
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
        public IActionResult About()
        {
            return View("about-us");
        }
        public IActionResult CoursesDetail()
        {
            return View("course-details");
        }
        public IActionResult Courses()
        {
            return View("courses");
        }
        public IActionResult Elements()
        {
            return View("elements");
        }
        public IActionResult Blog()
        {
            return View("blog");
        }
        public IActionResult BlogDetail()
        {
            return View("single-blog");
        }
        public IActionResult Contact()
        {
            return View("contact");
        }
        
    }
}