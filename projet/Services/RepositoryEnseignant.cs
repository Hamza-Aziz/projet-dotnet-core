using projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Services
{
    public interface RepositoryEnseignant
    {

        void SaveEns(Enseignant Ens);
        void DeleteEns(int id);
        void UpdateEns(Enseignant enseignant);
        IEnumerable<Enseignant> FindAllEns();
        Enseignant GetEnsbyID(int id);


    }
}
