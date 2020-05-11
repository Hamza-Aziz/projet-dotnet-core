using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class PrjContext : DbContext
    {
        public PrjContext(DbContextOptions<PrjContext> options) : base(options)
        {
        }
        public DbSet<niveau> Niveaus { get; set; }

        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Filiere> Filieres { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<chapitre> chapitres { get; set; }

        public DbSet<Admin> Admins{ get; set; }
    }
}
