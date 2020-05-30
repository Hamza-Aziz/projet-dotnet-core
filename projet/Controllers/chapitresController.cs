using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet.Models;
using projet.ViewModels;

namespace projet.Controllers
{
    public class chapitresController : Controller
    {
        private readonly PrjContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        public chapitresController(PrjContext context,IHostingEnvironment hostingEnvironment)
        {
            _context = context; _hostingEnvironment = hostingEnvironment;

        }

        // GET: chapitres
        public async Task<IActionResult> Index()
        {
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            var prjContext = _context.chapitres.Include(c => c.Module);
            return View(await prjContext.ToListAsync());
        }

        // GET: chapitres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapitre = await _context.chapitres
                .Include(c => c.Module)
                .FirstOrDefaultAsync(m => m.id_chap == id);
            if (chapitre == null)
            {
                return NotFound();
            }
                 ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View(chapitre);
        }

        // GET: chapitres/Create
        public IActionResult Create()
        {
            //ViewData["id_mod"] = new SelectList(_context.Modules, "id_mod", "nom_mod");
            ViewBag.id_mod = new SelectList(_context.Modules, "id_mod", "nom_mod");
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View();
        }
        //[Bind("id_chap,type,contenu,date_depot,responsable,id_mod")] 
        // POST: chapitres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChapitreViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                //ViewData["id_mod"] = new SelectList(_context.Modules, "id_mod", "nom_mod");

                chapitre chap = new chapitre
                {
                    id_chap = model.id_chap,
                    type = model.type,

                    date_depot = model.date_depot,
                    responsable = model.responsable,
                    id_mod = model.id_mod,

                contenu = uniqueFileName,
                };
                _context.Add(chap);
                await _context.SaveChangesAsync();
                ViewBag.id_mod = new SelectList(_context.Modules, "id_mod", "nom_mod");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.id_mod = new SelectList(_context.Modules, "id_mod", "nom_mod");
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View();
        }

        private string UploadedFile(ChapitreViewModel model)
        {
            string uniqueFileName=null;

            if (model.contenuu != null)
            {
                string uploadssFolder = Path.Combine(_hostingEnvironment.WebRootPath, "UploadChap");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.contenuu.FileName;
                string filePath = Path.Combine(uploadssFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.contenuu.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        // GET: chapitres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapitre = await _context.chapitres.FindAsync(id);
            if (chapitre == null)
            {
                return NotFound();
            }
            ViewData["id_mod"] = new SelectList(_context.Modules, "id_mod", "nom_mod", chapitre.id_mod);
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View(chapitre);
        }

        // POST: chapitres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_chap,type,contenu,date_depot,responsable,id_mod")] chapitre chapitre)
        {
            if (id != chapitre.id_chap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chapitre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!chapitreExists(chapitre.id_chap))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_mod"] = new SelectList(_context.Modules, "id_mod", "nom_mod", chapitre.id_mod);
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View(chapitre);
        }

        // GET: chapitres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapitre = await _context.chapitres
                .Include(c => c.Module)
                .FirstOrDefaultAsync(m => m.id_chap == id);
            if (chapitre == null)
            {
                return NotFound();
            }
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View(chapitre);
        }

        // POST: chapitres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chapitre = await _context.chapitres.FindAsync(id);
            _context.chapitres.Remove(chapitre);
            await _context.SaveChangesAsync();
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return RedirectToAction(nameof(Index));
        }

        private bool chapitreExists(int id)
        {
            return _context.chapitres.Any(e => e.id_chap == id);
        }
    }
}
