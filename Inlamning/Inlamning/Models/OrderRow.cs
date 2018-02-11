using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inlamning.Models
{
    public class OrderRow
    {

        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Orders Order { get; set; }

        public int ProduktId { get; set; }

        [ForeignKey("ProduktId")]
        public virtual Produkt Product { get; set; }

        public int Amount { get; set; }

    }
}