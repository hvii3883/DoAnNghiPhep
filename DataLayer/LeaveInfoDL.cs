using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferObject;

namespace DataLayer
{
    public class LeaveInfoDL : DataProvider
    {
        public LeaveInfoDTO GetLeaveInfoByEmail(string email)
        {
            LeaveInfoDTO info = null;

            string query = "Usp_GetLeaveInfoEmail";

            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Email", email)
        };

            DataTable dt = Instance.MyExecuteQuery(query, CommandType.StoredProcedure, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                info = new LeaveInfoDTO
                {
                    Email = row["Email"].ToString(),
                    FullName = row["FullName"].ToString(),
                    TotalLeaveDays = Convert.ToInt32(row["TotalLeaveDays"]),
                    DaysTaken = Convert.ToInt32(row["DaysTaken"]),
                    DaysRemaining = Convert.ToInt32(row["DaysRemaining"])
                };
            }
            return info;
        }
    }
}

