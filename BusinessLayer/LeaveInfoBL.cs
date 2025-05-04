using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferObject;

namespace BusinessLayer
{
    public class LeaveInfoBL
    {
        private LeaveInfoDL dal = new LeaveInfoDL();

        public LeaveInfoDTO GetLeaveInfoByEmail(string email)
        {
            return dal.GetLeaveInfoByEmail(email);
        }
    }
}
