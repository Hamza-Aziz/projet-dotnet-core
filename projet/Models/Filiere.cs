using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class Filiere
    {
        public Filiere()
        {
            this.Niveaus = new HashSet<niveau>();
        }

        [Key]
        [Required]
        public int id_fil { get; set; }
        [Required]
        public string nom_fil { get; set; }
        public virtual ICollection<niveau> Niveaus { get; set; }

    }
}
