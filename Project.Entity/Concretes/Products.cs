using Project.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class Products : IBaseTable
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int ModelId { get; set; }
        public int ColourId { get; set; }
        public int VatId { get; set; }
        public int UnitId { get; set; }

        [ForeignKey("VatId")]

        public Vat Vat { get; set; }

        [ForeignKey("UnitId")]

        public Unit Unit { get; set; }

        [ForeignKey("ModelId")]

        public Model Model { get; set; }

        [ForeignKey("ColourId")]

        public Colour Colour { get; set; }

        public ICollection<BasketDetail> BasketDetail { get; set; }

      




    }
}
