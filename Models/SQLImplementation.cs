using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Models
{
    public class SQLImplementation : IEmployeeRepositoryPattern
    {
        private readonly SQLDbContext _context;
        private readonly ILogger<SQLImplementation> _logger;

        public SQLImplementation(SQLDbContext context, ILogger<SQLImplementation> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetListOfEmployees()
        {
            return _context.Employees;
        }

        public Employee UpdateEmployeeInfo(Employee employeeChanges)
        {
            var emp = _context.Employees.Attach(employeeChanges);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return employeeChanges;
        }
    }
}
