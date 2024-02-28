using Microsoft.EntityFrameworkCore;
using MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
   public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(MvcDBContext Context)
                 : base(Context)
        {

        }

        public async Task<bool> AddEmployee(Employee Employee)
        {

            Employee.Status = 'A';
            Employee.CreatedBy = "user";
            Employee.CreatedDate = DateTime.Now;
            Employee.AppKey = "CMS";
            Employee.Action = 'I';

            var result= await _dbContext.Employees.AddAsync(Employee);
            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var dbEmployee =await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id && x.Status == ActiveConst.Active);
            dbEmployee.Status = ActiveConst.Delete;
            dbEmployee.UpdatedBy = "test";
            dbEmployee.UpdatedDate = DateTime.Now;
            _dbContext.Entry(dbEmployee).State = EntityState.Modified;

            return dbEmployee;
        }

        public async Task<Employee> EditEmployee(Employee Employee)
        {
            var dbEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Employee.Id && x.Status == ActiveConst.Active);
            dbEmployee.UpdatedBy = "test";
            dbEmployee.UpdatedDate = DateTime.Now;
            dbEmployee.Name = Employee.Name;
            dbEmployee.Remarks = Employee.Remarks;
            _dbContext.Entry(dbEmployee).State = EntityState.Modified;

            return dbEmployee;
        }

        public async Task<Employee> GetDetailEmployee(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id );
        }

        public IQueryable<Employee> GetEmployees(EmployeeParam Params)
        {
            var Employees = _dbContext.Employees.Where(x => x.Status == ActiveConst.Active).AsQueryable();
            if (!string.IsNullOrEmpty(Params.Name))
            {
                Employees = Employees.Where(x => x.Name.ToLower().Contains(Params.Name.ToLower())).OrderByDescending(x=>x.Id);
                
            }
            else
            {
                Employees = Employees.OrderByDescending(x => x.Id);
            }
            return Employees;
        }
    }
}
