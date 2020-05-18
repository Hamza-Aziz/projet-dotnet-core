using NPOI.OpenXml4Net.OPC.Internal;
using projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Services
{
    public class FiliereServices : RepositoryFiliere
    {
        private readonly PrjContext _context;

        public FiliereServices(PrjContext ctxt)
        {
            _context = ctxt;
        }

        public void Savefil(Filiere fil)
        {
            _context.Add(fil);
            _context.SaveChanges();
        }

        public void Deletefil(int id)
        {
            var fil = _context.Filieres.Find(id);
            _context.Filieres.Remove(fil);

            List<niveau> nivx = _context.Niveaus.Where(c => c.id_fil == id).ToList();

            foreach(var item in nivx)
            {
                _context.Niveaus.Remove(item);
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }

        public void Updatefil(Filiere fil)
        {
            _context.Update(fil);
            _context.SaveChanges();
        }

        public IEnumerable<Filiere> FindAllfil()
        {
            return _context.Filieres.ToList();
        }

        public Filiere GetfilbyID(int id)
        {
            return _context.Filieres.Find(id);
        }

        public void Saveniv(niveau niv)
        {
            _context.Add(niv);
            _context.SaveChanges();
        }

    }
}
