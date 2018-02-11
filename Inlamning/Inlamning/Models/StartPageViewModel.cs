using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inlamning.Models
{
    public class StartPageViewModel
    {
        //list som inhåller objekt
        public List<Produkt> Products { get; set; }

        public string Cart { get; set; }
    }
}