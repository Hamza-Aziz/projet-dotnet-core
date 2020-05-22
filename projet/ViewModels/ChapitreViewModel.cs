using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projet.ViewModels
{
    public class ChapitreViewModel
    {
         
        [Key]
        [Required]
        public int id_chap { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public IFormFile contenuu { get; set; }
        [Required]
        public string date_depot { get; set; }
        [Required]
        public string responsable { get; set; }

        public int id_mod { get; set; }


   
}
}
