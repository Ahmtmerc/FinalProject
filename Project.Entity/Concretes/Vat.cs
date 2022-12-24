using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class Vat:BaseDescription
    {

        public decimal Ratio { get; set; }

        public ICollection<Products> Products { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }

    }
}
