using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class niveau
    {
        public niveau()
        {
           this.Modules = new HashSet<Module>();
        }

        [Key]
        [Required]
        public int id_niv{ get; set; }
        [Required]
        public string nom_niv { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        [ForeignKey("Filiere")]
        public Nullable<int> id_fil { get; set; }
        public virtual Filiere Filiere { get; set; }


    }
}
