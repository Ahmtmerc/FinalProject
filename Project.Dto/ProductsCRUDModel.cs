using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dto
{
    public class ProductsCRUDModel
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int ModelId { get; set; }
        public int ColourId { get; set; }
        public int VatId { get; set; }
        public int UnitId { get; set; }

    }
}
