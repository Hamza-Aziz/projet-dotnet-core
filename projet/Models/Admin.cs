using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class Admin
    {

       
        public int Id{ get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string mdp { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string photo { get; set; }
        public string role { get; set; }

    }
}
