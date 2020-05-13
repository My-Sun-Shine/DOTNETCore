using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employee = new List<Employee>();

        public EmployeeService()
        {
            _employee.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Carter",
                Gender = Gender.男
            });
            _employee.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Michas",
                LastName = "jasder",
                Gender = Gender.男
            });
            _employee.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Marid",
                LastName = "Carey",
                Gender = Gender.女
            });
            _employee.Add(new Employee
            {
                Id = 4,
                DepartmentId = 2,
                FirstName = "Nickaa",
                LastName = "Carteaaaa",
                Gender = Gender.男
            });
            _employee.Add(new Employee
            {
                Id = 5,
                DepartmentId = 2,
                FirstName = "Michdddas",
                LastName = "jasdddder",
                Gender = Gender.男
            });
            _employee.Add(new Employee
            {
                Id = 6,
                DepartmentId = 2,
                FirstName = "aaMarid",
                LastName = "aaCarey",
                Gender = Gender.女
            });
            _employee.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "Nidddck",
                LastName = "Carddter",
                Gender = Gender.男
            });
            _employee.Add(new Employee
            {
                Id = 8,
                DepartmentId = 3,
                FirstName = "Middchas",
                LastName = "jasdddder",
                Gender = Gender.男
            });
            _employee.Add(new Employee
            {
                Id = 9,
                DepartmentId = 3,
                FirstName = "Mar110id",
                LastName = "Car10ey",
                Gender = Gender.女
            });

        }

        public Task Add(Employee employee)
        {
            employee.Id = _employee.Max(x => x.Id) + 1;
            _employee.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employee.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employee.Where(x => x.DepartmentId == departmentId).AsEnumerable());
        }
    }
}
