using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DBContext _context;
        private DbSet<TEntity> _dbset;
        public Repository(DBContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public TEntity Find(int recordId)
        {
            return _dbset.Find(recordId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public void Remove(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }

        public void Update(int id, TEntity entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
