using Project.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class BasketDetail : IBaseTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BmId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public int VatId { get; set; }
        public int UnitId { get; set; }

        [ForeignKey("ProductId")]

        public Products Products { get; set; }

        [ForeignKey("BmId")]

        public BasketMaster BasketMaster { get; set; }

        [ForeignKey("VatId")]

        public Vat Vat { get; set; }

        [ForeignKey("UnitId")]

        public Unit Unit { get; set; }

    }
}
