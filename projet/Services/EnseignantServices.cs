using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projet.Models;

namespace projet.Services
{
    public class EnseignantServices : RepositoryEnseignant
    {
        private readonly PrjContext _context;
        
        public EnseignantServices(PrjContext contextDB)
        {
            _context = contextDB;
        }
        public void DeleteEns(int id)
        {
            var enseignant = _context.Enseignants.Find(id);
            _context.Enseignants.Remove(enseignant);
            _context.SaveChanges();
        }

        public IEnumerable<Enseignant> FindAllEns()
        {
            return _context.Enseignants.ToList();
        }

        public Enseignant GetEnsbyID(int id)
        {
            Enseignant ens = _context.Enseignants.Find(id);
            return ens;
        }

        public void SaveEns(Enseignant Ens)
        {
            _context.Add(Ens);
            _context.SaveChanges();
        }

        public void UpdateEns(Enseignant enseignant)
        {
            _context.Update(enseignant);
            _context.SaveChanges();
        }
    }
}
