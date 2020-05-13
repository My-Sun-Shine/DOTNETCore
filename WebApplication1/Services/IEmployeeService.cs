using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);

        Task<Employee> Fire(int id);

        Task Add(Employee employee);
    }
}
