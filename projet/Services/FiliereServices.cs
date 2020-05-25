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
            

            List<niveau> nivx = _context.Niveaus.Where(c => c.id_fil == id).ToList();

            foreach (var item in nivx)
            {
                _context.Niveaus.Remove(item);
                _context.SaveChanges();
            }

            var fil = _context.Filieres.Find(id);
            _context.Filieres.Remove(fil);

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


        public IEnumerable<niveau> FindAllniv(int id)
        {
            List<niveau>niv = _context.Niveaus.ToList();
            List<niveau> nivv = new List<niveau>();

            foreach(var item in niv)
            {
                if (item.id_fil == id)
                {
                    nivv.Add(item);
                }
            }

            return nivv;
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


        public niveau GetnivbyID(int id)
        {
            return _context.Niveaus.Find(id);
        }
        public void Deleteniv(int id)
        {
            var niv = _context.Niveaus.Find(id);
            _context.Niveaus.Remove(niv);
            _context.SaveChanges();
        }

        public void Updateniv(niveau niv)
        {

            _context.Update(niv);
            _context.SaveChanges();
        }

    }
}