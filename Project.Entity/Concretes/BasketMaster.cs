using Project.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class BasketMaster : IBaseTable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("UserId")]

        public Users Users { get; set; }

        public ICollection<BasketDetail> BasketDetails { get; set; }

    }
}
