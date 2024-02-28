using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Common;
using MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Controllers
{
    
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees([FromQuery] EmployeeParam param)
        {
            var Employees = await _EmployeeService.GetEmployees(param);
            Response.AddPaginationHeader(Employees.CurrentPage, Employees.PageSize,
            Employees.TotalCount, Employees.TotalPages);
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetDetailEmployee(int id)
        {
            var EmployeeDto = await _EmployeeService.GetDetailEmployee(id);
            if (EmployeeDto == null) return NotFound();
            else return Ok(EmployeeDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee Employee)
        {
          var result=  await _EmployeeService.AddEmployee(Employee);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditEmployee(Employee Employee)
        {
           var result= await _EmployeeService.EditEmployee(Employee);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await _EmployeeService.DeleteEmployee(id);
            return Ok(result);
        }


    }
}
