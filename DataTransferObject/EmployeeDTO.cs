using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class EmployeeDTO
    {
       
        public string FullName { get; set; }
   
        public string Email { get; set; }
        public int TotalLeaveDays { get; set; }
    }
}
