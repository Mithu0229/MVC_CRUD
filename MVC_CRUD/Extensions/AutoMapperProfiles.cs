using AutoMapper;
using MVC.Common;
using MVC.DataAccess;

namespace MVC_CRUD.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            
        }
    }
}
