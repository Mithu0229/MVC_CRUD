using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
    public class Employee : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Gmail { get; set; }
        public string Mobile { get; set; }
        public int GenderId { get; set; }
        public DateTime DOB { get; set; }
        public string Hobbies { get; set; }
        public int DivisionId { get; set; }
        public int District { get; set; }
        public bool IsMarried { get; set; }
        public string Remarks { get; set; }
    }
}
