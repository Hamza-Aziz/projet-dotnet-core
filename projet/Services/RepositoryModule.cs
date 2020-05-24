using projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Services
{
    public interface RepositoryModule
    {
        void SaveChap(chapitre chap);

        void SaveMod(Module mod);
        void DeleteMod(int id);
        void UpdateMod(Module module);
        IEnumerable<Module> FindAllMod();
        Module GetModbyID(int id);
    }
}
