
using MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
   public interface IEmployeeRepository : IRepository<Employee> 
    {
       IQueryable<Employee> GetEmployees(EmployeeParam Params);
        Task<Employee> GetDetailEmployee(int id);
        Task<bool> AddEmployee(Employee Employee);
        Task<Employee> EditEmployee(Employee Employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
