
using MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
   public class MvcUnitOfWork : UnitOfWork<MvcDBContext>, IMvcUnitOfWork
    {
        private readonly MvcDBContext _context;


        public MvcUnitOfWork(MvcDBContext context)
            : base(context)
        { 
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
            
        }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        
    }
}
