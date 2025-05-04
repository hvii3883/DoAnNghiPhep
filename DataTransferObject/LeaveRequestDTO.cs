using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class LeaveRequestDTO
    {
        public int RequestID { get; set; }
        public string EmpEmail { get; set; }
        public int TypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; } // 0: Pending, 1: Approved, 2: Rejected
        public string ApprovedBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        
    }


}
