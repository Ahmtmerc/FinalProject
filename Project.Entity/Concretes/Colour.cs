using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class Colour:BaseDescription
    {
        public ICollection<Products> Products { get; set; }
    }
}
