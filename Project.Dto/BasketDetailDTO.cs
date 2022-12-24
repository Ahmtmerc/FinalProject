using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dto
{
    public class BasketDetailDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitId { get; set; }
        public int Amount { get; set; }
        public decimal Ratio { get; set; }
        //public int ProductId { get; set; }
        //public int BmId { get; set; }
        public decimal Total { get; set; }
        public string ColourName { get; set; }



    }
}