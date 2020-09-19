using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DBContext _context;
        public EmployeeRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
