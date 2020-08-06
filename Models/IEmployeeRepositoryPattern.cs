using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Models
{
    public interface IEmployeeRepositoryPattern
    {
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> GetListOfEmployees();
        Employee UpdateEmployeeInfo(Employee employeeChanges);
        Employee DeleteEmployee(int id);
    }
}
