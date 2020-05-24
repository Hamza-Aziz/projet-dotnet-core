using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using projet.Models;
namespace projet.Controllers
{
    public class HomeController : Controller
    {
        private PrjContext _context;
        int numberOfchapter;
        List<ExpandoObject> lastUploadedChapter = new List<ExpandoObject>();
        List<ExpandoObject> chapitreFound = new List<ExpandoObject>();
        List<ExpandoObject> filierePrNiveau = new List<ExpandoObject>();
        IQueryable<string> moduleInDataBase;
        public HomeController(PrjContext context)
        {
            _context = context;
            numberOfchapter = _context.chapitres.ToList().Count();
            //i should do a join of 3 table and passe the attribut nedded to a list and passe it to the view Index
            //moduleInDataBase = from m in _context.Modules orderby m.nom_mod select m.nom_mod;

            var query = (from chapter in _context.chapitres
                         join module in _context.Modules on chapter.id_mod equals module.id_mod
                         join ensiegnant in _context.Enseignants on module.Id equals ensiegnant.Id
                         join level in _context.Niveaus on module.id_niv equals level.id_niv
                         select new
                         {
                             contenuOfChapter = chapter.contenu,
                             enseignatOfmodule = ensiegnant.nom + " " + ensiegnant.prenom,
                             dateUploade = chapter.date_depot,
                             nameOfModule = module.nom_mod,
                             niveauOfModule = level.nom_niv,
                             idChapter = chapter.id_chap,
                             photoOfensignant = ensiegnant.photo,
                             nameOfchapter = chapter.contenu

                         });
            int countElements = 0; //on va afficher just les 4 dernier cours d'ou le besoin de ce variable
                                   ////////////////////////////////////////////////////////////////filiere////////////////////////////////////////////////////////////
            var forHelp = (from f in _context.Filieres
                           join n in _context.Niveaus on f.id_fil equals n.id_fil
                           select new
                           {
                               filiere = f,
                               level = n

                           }).ToList();
            var filierePrNiveauQuery = from p in forHelp
                                       group p.level by p.filiere into g
                                       select new { filiere = g.Key, niveaux = g.ToList() };

            foreach (var item in filierePrNiveauQuery)
            {


                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor property
                         in
                         TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(property.Name, property.GetValue(item));
                }
                filierePrNiveau.Add(itemExpando as ExpandoObject);

            }
            ////////////////////////////////////////////////////////////////fin filiere////////////////////////////////////////////////////////////
            foreach (var item in query)
            {
                if (countElements == 4)
                    break;
                else
                {

                    IDictionary<string, object> itemExpando = new ExpandoObject();
                    foreach (PropertyDescriptor property
                             in
                             TypeDescriptor.GetProperties(item.GetType()))
                    {
                        itemExpando.Add(property.Name, property.GetValue(item));
                    }
                    lastUploadedChapter.Add(itemExpando as ExpandoObject);
                    countElements++;
                }
            }

        }


        public IActionResult Index()
        {
            ViewBag.numberOfchapter = numberOfchapter;
            ViewBag.lastUploadedChapter = lastUploadedChapter;

            return View();
        }
        public IActionResult About()
        {
            List<Enseignant> list = new List<Enseignant>();
            list = _context.Enseignants.ToList();
            ViewBag.numberOfchapter = numberOfchapter;
            return View("about-us", list);
        }
        public IActionResult CoursesDetail()
        {
            return View("course-details");
        }
        public IActionResult contact_process()
        {
            ViewBag.msg = "nous avons récupéré votre message,Nous allons vous répondre bientôt ";
            return View("contact");
        }
        [HttpPost]
        public IActionResult Courses(string moduleChoisis, string searchString)
        {
            ViewBag.moduleInDataBase = new SelectList("");
            ViewBag.lastUploadedChapter = lastUploadedChapter;
            var query = (from chapter in _context.chapitres
                         join module in _context.Modules on chapter.id_mod equals module.id_mod
                         join ensiegnant in _context.Enseignants on module.Id equals ensiegnant.Id
                         join level in _context.Niveaus on module.id_niv equals level.id_niv
                         select new
                         {
                             contenuOfChapter = chapter.contenu,
                             enseignatOfmodule = ensiegnant.nom + " " + ensiegnant.prenom,
                             dateUploade = chapter.date_depot,
                             nameOfModule = module.nom_mod,
                             niveauOfModule = level.nom_niv,
                             idChapter = chapter.id_chap,
                             photoOfensignant = ensiegnant.photo,
                             nameOfchapter = chapter.contenu

                         });
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.nameOfchapter.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(moduleChoisis))
            {
                query = query.Where(s => s.nameOfModule.Contains(moduleChoisis));
            }
            ViewBag.notFound = "";
            if (query.Count() == 0)
            {
                ViewBag.notFound = "oops nous n'avons trouvez aucun cours contenants le mot '" + searchString + "'";
            }
            else
            {
                foreach (var item in query)
                {


                    IDictionary<string, object> itemExpando = new ExpandoObject();
                    foreach (PropertyDescriptor property
                             in
                             TypeDescriptor.GetProperties(item.GetType()))
                    {
                        itemExpando.Add(property.Name, property.GetValue(item));
                    }
                    chapitreFound.Add(itemExpando as ExpandoObject);

                }
            }
            ViewBag.chapitreFound = chapitreFound;
            ViewBag.filierePrNiveau = filierePrNiveau;
            return View("courses");
        }
        public IActionResult Courses()
        {
            ViewBag.filierePrNiveau = filierePrNiveau;
            ViewBag.chapitreFound = chapitreFound;
            ViewBag.moduleInDataBase = new SelectList("");
            ViewBag.lastUploadedChapter = lastUploadedChapter;
            return View("courses");
        }
        //functions for help
        //fonction that return the list of module of a level founded in the data base
        public List<string> getModulesOflevel(int? idNiveau)
        {
            List<string> moduleInDataBase = (from m in _context.Modules orderby m.nom_mod where m.id_niv == idNiveau select m.nom_mod).Distinct().ToList();
            return moduleInDataBase;
        }

        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            if (fileName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/UploadChap", fileName);

            var memory = new MemoryStream();
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(path), Path.GetFileName(path));
            }
            catch (FileNotFoundException)
            {
                ViewBag.notFound = "oops le document n'est plus disponible ou a été supprimé";
                ViewBag.filierePrNiveau = filierePrNiveau;
                ViewBag.chapitreFound = chapitreFound;
                ViewBag.moduleInDataBase = new SelectList("");
                ViewBag.lastUploadedChapter = lastUploadedChapter;
                return View("Courses");
            }
           
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats  " +
                "officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        public IActionResult getCourses(int? idNiveau, int? idFiliere)
        {
            if (idFiliere == null || idNiveau == null)
            {
                return NotFound();
            }
            else
            {
                var queryCoursesDispo = (from chapter in _context.chapitres
                                         join module in _context.Modules on chapter.id_mod equals module.id_mod
                                         join ensiegnant in _context.Enseignants on module.Id equals ensiegnant.Id
                                         join level in _context.Niveaus on module.id_niv equals level.id_niv
                                         where level.id_niv == idNiveau
                                         join filiere in _context.Filieres on level.id_fil equals filiere.id_fil
                                         where filiere.id_fil == idFiliere
                                         select new
                                         {
                                             contenuOfChapter = chapter.contenu,
                                             enseignatOfmodule = ensiegnant.nom + " " + ensiegnant.prenom,
                                             dateUploade = chapter.date_depot,
                                             nameOfModule = module.nom_mod,
                                             niveauOfModule = level.nom_niv,
                                             idChapter = chapter.id_chap,
                                             photoOfensignant = ensiegnant.photo,
                                             nameOfchapter = chapter.contenu,
                                         });
                if (queryCoursesDispo.Count() == 0)
                {
                    ViewBag.notFound = "oops nous n'avons trouvez aucun cours dans ce niveau";
                }
                else
                {
                    ViewBag.Found = "vous trouvrez ci-dessous les  cours publiés par vos ensignants au niveau '" + _context.Niveaus.Where(n => n.id_niv == idNiveau).FirstOrDefault().nom_niv+"'";
                }

                foreach (var item in queryCoursesDispo)
                {


                    IDictionary<string, object> itemExpando = new ExpandoObject();
                    foreach (PropertyDescriptor property
                             in
                             TypeDescriptor.GetProperties(item.GetType()))
                    {
                        itemExpando.Add(property.Name, property.GetValue(item));
                    }
                    chapitreFound.Add(itemExpando as ExpandoObject);

                }
                ViewBag.moduleInDataBase = new SelectList(getModulesOflevel(idNiveau));
                ViewBag.chapitreFound = chapitreFound;
                ViewBag.lastUploadedChapter = lastUploadedChapter;
                ViewBag.filierePrNiveau = filierePrNiveau;
                return View("courses");

            }


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