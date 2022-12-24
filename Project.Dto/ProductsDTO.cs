using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dto
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public string Vat { get; set; }
        public decimal Ratio { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
   
    }
}
