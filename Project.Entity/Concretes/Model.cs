using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class Model : BaseDescription
    {
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]

        public Brand Brand { get; set; }



        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public Category Category { get; set; }



    }
}
