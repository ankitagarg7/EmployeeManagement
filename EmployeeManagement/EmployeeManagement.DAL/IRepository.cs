using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int recordId);

        void Add(TEntity entity);

        void Update(int id, TEntity entity);

        void Remove(TEntity entity);
    }
}
