
using MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
   public interface IMvcUnitOfWork : IUnitOfWork<MvcDBContext>, IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        
    }
}
