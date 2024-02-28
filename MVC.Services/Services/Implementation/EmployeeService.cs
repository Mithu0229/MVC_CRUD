using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MVC.Common;
using MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
   public class EmployeeService : IEmployeeService
    {
        private readonly IMvcUnitOfWork _petUnitOfWork;
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IMvcUnitOfWork petUnitOfWork, IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _petUnitOfWork = petUnitOfWork;
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddEmployee(Employee Employee)
        {
            try
            {
                var result =await _EmployeeRepository.AddEmployee(Employee);
                if (result)
                {
                   await _petUnitOfWork.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.ErrorLg("AddEmployee", ex.Message);
            }
            return false;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            try
            {
                var result =await _EmployeeRepository.DeleteEmployee(id);
                if(result != null)
                {
                    await  _petUnitOfWork.Save();
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLg("DeleteEmployee", ex.Message);
            }
            return null;
            
        }

        public async Task<Employee> EditEmployee(Employee Employee)
        {
            try
            {
                var result = await _EmployeeRepository.EditEmployee(Employee);
                if(result != null)
                {
                    await _petUnitOfWork.Save();
                    return result;
                }
            }
            catch (Exception ex)
            {

                ErrorLog.ErrorLg("EditEmployee", ex.Message);
            }
            return null;
          
        }

        public async Task<Employee> GetDetailEmployee(int id)
        {
            try
            {
                if (id != 0)
                {
                    var result = await _EmployeeRepository.GetDetailEmployee(id);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLg("GetDetailEmployee", ex.Message);
            }

            return null;
            
        }

        public async Task<PagedList<EmployeeDto>> GetEmployees(EmployeeParam param)
        {
            IQueryable<Employee> Employees = null;
            try
            {
                 Employees = _EmployeeRepository.GetEmployees(param);
                return await PagedList<EmployeeDto>.CreateAsync(Employees.ProjectTo<EmployeeDto>
                 (_mapper.ConfigurationProvider).AsNoTracking(), param.PageNumber, param.PageSize);

            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLg("Employees", ex.Message);
            }
            return await PagedList<EmployeeDto>.CreateAsync(null,1,1);
        }
    }
}
