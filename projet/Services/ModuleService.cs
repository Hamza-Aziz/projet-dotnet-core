using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projet.Models;

namespace projet.Services
{
    public class ModuleService : RepositoryModule
    {
        private readonly PrjContext _context;

        public ModuleService(PrjContext context)
        {
            _context = context;
        }

        public void DeleteMod(int id)
        {
            var module = _context.Modules.Find(id);
            _context.Modules.Remove(module);
            _context.SaveChanges();
        }

        public IEnumerable<Module> FindAllMod()
        {
            return _context.Modules.Include(e => e.Enseignant).Include(e => e.niveau);
        }

        public Module GetModbyID(int id)
        {
            Module mod = _context.Modules.Find(id);
            return mod;
        }

        public void SaveMod(Module mod)
        {
            _context.Add(mod);
            _context.SaveChanges();
        }
        public void SaveChap(chapitre chap)
        {
            _context.Add(chap);
            _context.SaveChanges();
        }

        public void UpdateMod(Module module)
        {
            _context.Update(module);
            _context.SaveChanges();
        }

        
    }
}
