using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using projet.Models;
namespace projet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PrjContext _context;
        public HomeController(ILogger<HomeController> logger, PrjContext context)
        {
            _logger = logger;
            _context = context;
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
        public IActionResult LoginAdmin()
        {
            return View();
        }
        public IActionResult LoginEnseignant()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAdminProcessed([Bind("username,mdp")] Admin claimedAdmin)
        {
            Admin admin = await _context.Admins.Where(x => x.username == claimedAdmin.username && x.mdp == claimedAdmin.mdp).FirstOrDefaultAsync();
            if (admin != null)
            {
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                ViewBag.error = "username or password is invalid,Try again !";
                return View("LoginAdmin");
            }
            // 
            
        }
        [HttpPost]
        public async Task<IActionResult> LoginEnseignantProcessed([Bind("email,mdp")] Enseignant claimedEnseignant)
        {
            Enseignant enseignant=await _context.Enseignants.Where(x => x.email == claimedEnseignant.email && x.mdp == claimedEnseignant.mdp).FirstOrDefaultAsync();
            
            if (enseignant != null)
            {
                HttpContext.Session.SetString("nom", enseignant.nom +" "+ enseignant.prenom);
                HttpContext.Session.SetString("username", enseignant.username);
                HttpContext.Session.SetInt32("id", enseignant.Id);
                return RedirectToAction("Index1", "Modules");
            }
            else
            {
                ViewBag.error = "email or password is invalid,Try again !";
                return View("LoginEnseignant");
            }
        }

    }
}