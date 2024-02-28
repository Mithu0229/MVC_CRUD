
using MVC.Common;
using MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
   public interface IEmployeeService
    {
        Task<PagedList<EmployeeDto>> GetEmployees(EmployeeParam Params);
        Task<Employee> GetDetailEmployee(int id);
        Task<bool> AddEmployee(Employee Employee);
        Task<Employee> EditEmployee(Employee Employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
