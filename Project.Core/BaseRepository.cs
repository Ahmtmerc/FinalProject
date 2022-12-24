using Microsoft.EntityFrameworkCore;
using Project.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ProjectContext _db;

        public BaseRepository(ProjectContext db)
        {
            _db = db;
        }

        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(T entity, int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }

        public T Find(int Id, int Id2)
        {
            return Set().Find(Id, Id2);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}