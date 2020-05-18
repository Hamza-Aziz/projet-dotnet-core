using projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Services
{
    public interface RepositoryFiliere
    {
        void Savefil(Filiere fil);
        void Deletefil(int id);
        void Updatefil(Filiere fil);
        IEnumerable<Filiere> FindAllfil();
        Filiere GetfilbyID(int id);
        void Saveniv(niveau niv);
    }
}
