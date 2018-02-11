using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inlamning.Models
{
    public class Produktviewmodel
    {
        public int Id { get; set; }
        [Required]
        public string ProduktName { get; set; }
        public string Beskrvning { get; set; }
        [Display(Name = "Pris i kr")]
        public int Pris { get; set; }

        public string bild { get; set; }


    }
}