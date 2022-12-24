using Project.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Concretes
{
    public class BaseDescription : IBaseTable, IBaseDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
