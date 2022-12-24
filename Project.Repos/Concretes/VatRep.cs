using Project.Core;
using Project.Dal;
using Project.Entity.Concretes;
using Project.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repos.Concretes
{
    public class VatRep<T> : BaseRepository<Vat>, IVatRep where T : class
    {
        public VatRep(ProjectContext db) : base(db)
        {
        }
    }
}
