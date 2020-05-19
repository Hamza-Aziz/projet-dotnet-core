using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class Module
    {
        public Module()
        {
            this.chapitres = new HashSet<chapitre>();
        }

        [Key]
        [Required]
        public int id_mod { get; set; }
        [Required]
        public string nom_mod { get; set; }
        [ForeignKey("Enseignant")]
        public Nullable<int> Id { get; set; }
        public virtual Enseignant Enseignant{ get; set; }
        public virtual ICollection<chapitre> chapitres { get; set; }
        [ForeignKey("niveau")]
        public Nullable<int> id_niv { get; set; }
        public virtual niveau niveau { get; set; }




    }
}
