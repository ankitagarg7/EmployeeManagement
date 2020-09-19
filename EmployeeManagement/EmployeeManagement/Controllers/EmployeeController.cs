using EmployeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : ApiController
    {
        readonly UnitOfWork.UnitOfWork _unitOfWork;
        readonly Repository<Employee> _employees;
        public EmployeeController()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
            _employees = _unitOfWork.GetRepoInstance<Employee>();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees.Find(id);
        }

        public void Delete(int id)
        {
            _employees.Remove(_employees.Find(id));
            _unitOfWork.SaveChanges();
        }

        [HttpPost]
        public void Add(Employee employee)
        {
            _employees.Add(employee);
            _unitOfWork.SaveChanges();
        }

        [HttpPut]
        public void Update(int id, Employee employee)
        {
            Employee edit = _employees.Find(id);
            edit.FirstName = employee.FirstName;
            edit.LastName = employee.LastName;
            edit.Department = employee.Department;
            _employees.Update(id, edit);
            _unitOfWork.SaveChanges();
        }
    }
}
