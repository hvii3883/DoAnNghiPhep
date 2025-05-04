using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class LeaveInfoDTO
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int TotalLeaveDays { get; set; }
        public int DaysTaken { get; set; }
        public int DaysRemaining { get; set; }
    }
}
