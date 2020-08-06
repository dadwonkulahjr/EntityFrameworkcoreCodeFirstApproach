using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Models
{
    public class EmployeeImplementation : IEmployeeRepositoryPattern
    {
        private List<Employee> _listOfCustomEmployees;

        public EmployeeImplementation()
        {
            _listOfCustomEmployees = new List<Employee>()
            {
                new Employee(){Id=1, Fullname="Precious K Wonkulah", Department=Department.Management, Email="wonkulahp@gmail.com", Salary=5000},
                new Employee(){Id=2, Fullname="Crystal M Jones", Department=Department.Architectural_Engineering, Email="cjones@yahoo.com", Salary=8000},
                new Employee(){Id=3, Fullname="Dad S Wonkulah Jr", Department=Department.IT, Email="tuseTheProgrammer@outlook.com", Salary=10000}
            };
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _listOfCustomEmployees.Max(emp => emp.Id) + 1;
            _listOfCustomEmployees.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = _listOfCustomEmployees.FirstOrDefault(emp => emp.Id == id);
            if(employee != null)
            {
                _listOfCustomEmployees.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _listOfCustomEmployees.FirstOrDefault(emp => emp.Id == id);
        }

        public IEnumerable<Employee> GetListOfEmployees()
        {
            return _listOfCustomEmployees;
        }

        public Employee UpdateEmployeeInfo(Employee employeeChanges)
        {
           var updatedEmployee = _listOfCustomEmployees.FirstOrDefault(emp => emp.Id == employeeChanges.Id);
            if (updatedEmployee != null)
            {
                updatedEmployee.Fullname = employeeChanges.Fullname;
                updatedEmployee.Email = employeeChanges.Email;
                updatedEmployee.Department = employeeChanges.Department;
                updatedEmployee.Salary = employeeChanges.Salary;
            }
            return employeeChanges;
        }
    }
}
