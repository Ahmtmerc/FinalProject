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
    public class CategoryRep<T> : BaseRepository<Category>, ICategoryRep where T : class
    {
        public CategoryRep(ProjectContext db) : base(db)
        {
        }
    }
}
