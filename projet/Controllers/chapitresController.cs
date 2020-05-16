using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet.Models;

namespace projet.Controllers
{
    public class chapitresController : Controller
    {
        private readonly PrjContext _context;

        public chapitresController(PrjContext context)
        {
            _context = context;
        }

        // GET: chapitres
        public async Task<IActionResult> Index()
        {
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

            return View(chapitre);
        }

        // GET: chapitres/Create
        public IActionResult Create()
        {
            ViewData["id_mod"] = new SelectList(_context.Modules, "id_mod", "nom_mod");
            return View();
        }

        // POST: chapitres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_chap,type,contenu,date_depot,responsable,id_mod")] chapitre chapitre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chapitre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_mod"] = new SelectList(_context.Modules, "id_mod", "nom_mod", chapitre.id_mod);
            return View(chapitre);
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
            return RedirectToAction(nameof(Index));
        }

        private bool chapitreExists(int id)
        {
            return _context.chapitres.Any(e => e.id_chap == id);
        }
    }
}
