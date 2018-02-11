using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inlamning.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Customer { get; set; }

        public DateTime Created { get; set; }

        public bool Payed { get; set; }

        public bool Shipping { get; set; }

        public int Total { get; set; }

    }
}