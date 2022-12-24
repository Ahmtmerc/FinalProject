using Project.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class Users : IBaseTable
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Street { get; set; }
        public int Avenue { get; set; }
        public int No { get; set; }
        public int CountyId { get; set; }
        public bool Error { get; set; }
        public string Role { get; set; }
        public char Sex { get; set; }

        [ForeignKey("CountyId")]

        public County County { get; set; }
        public ICollection<BasketMaster> BasketMasters { get; set; }



    }
}
