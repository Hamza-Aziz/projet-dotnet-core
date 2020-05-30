using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet.Models;
using projet.Services;

namespace projet.Controllers
{
    [Authorize(Roles = "enseignant")]
    public class ModulesController : Controller
    {
        private readonly PrjContext _context;
        public static IEnumerable<Module>   mode;
        private readonly IHostingEnvironment _hostingEnvironment;
        private List<Module> listMod = new List<Module>();

        private RepositoryModule s1;
        private RepositoryEnseignant s2;

        public ModulesController(IHostingEnvironment hostingEnvironment, PrjContext _context, RepositoryModule s1, RepositoryEnseignant s2)
        {
            _hostingEnvironment = hostingEnvironment;
            this.s1 = s1;
            this.s2 = s2;
            this._context = _context;

        }
        public IActionResult Details(int id)
        {
            Module mod = s1.GetModbyID(id);
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");
            return View(mod);
        }
        // GET: Modules
        public async Task<IActionResult> Index()
        {
            var prjContext = _context.Modules.Include(e => e.Enseignant).Include(e => e.niveau);
   
            return View(await prjContext.ToListAsync());
        }

        // GET: Modules/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules
                .Include(e => e.Enseignant)
                .Include(e => e.niveau)
                .FirstOrDefaultAsync(m => m.id_mod == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }*/

        // GET: Modules/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "email");
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv");
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_mod,nom_mod,Id,id_niv")] Module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index1), mode);
            }
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "email", @module.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv", @module.id_niv);
            return View(@module);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "email", @module.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv", @module.id_niv);
            return View(@module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_mod,nom_mod,Id,id_niv")] Module @module)
        {
            if (id != @module.id_mod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module.id_mod))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index1), mode);
            }
            ViewData["Id"] = new SelectList(_context.Enseignants, "Id", "email", @module.Id);
            ViewData["id_niv"] = new SelectList(_context.Niveaus, "id_niv", "nom_niv", @module.id_niv);
            return View(@module);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules
                .Include(e => e.Enseignant)
                .Include(e =>e.niveau)
                .FirstOrDefaultAsync(m => m.id_mod == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @module = await _context.Modules.FindAsync(id);
            _context.Modules.Remove(@module);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index1), mode);
        }
        
        public IActionResult Index1()
        {

            
            var currentUserLastName = HttpContext.User.Claims.Where(x => x.Type == "nom").SingleOrDefault();
            var currentUserFirstName = HttpContext.User.Claims.Where(x => x.Type == "prenom").SingleOrDefault();

            int id2=0;
            foreach(var j in _context.Enseignants.ToList())
            {
                if(j.email.Equals(HttpContext.Session.GetString("email")) && j.mdp.Equals(HttpContext.Session.GetString("pass")))
                {
                    id2 = j.Id;
                }
            }


            mode = s1.FindAllMod(id2);
            HttpContext.Session.SetString("nom", currentUserLastName.ToString());

            HttpContext.Session.SetString("prenom", currentUserFirstName.ToString());
            ViewBag.nom = HttpContext.Session.GetString("nom");
            ViewBag.prenom = HttpContext.Session.GetString("prenom");

            return View(mode);
        }

  
        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.id_mod == id);
        }
    }
}
