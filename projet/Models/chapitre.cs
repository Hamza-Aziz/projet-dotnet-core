using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class chapitre
    {
        [Key]
        [Required]
        public int id_chap { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string contenu  { get; set; }
        [Required]
        public string date_depot { get; set; }
        [Required]
        public string responsable { get; set; }
        [ForeignKey("Module")]
        public Nullable<int> id_mod { get; set; }
        public virtual Module Module { get; set; }
    }
}
