using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LeaveRequestDL : DataProvider
    {
        public bool SendRequest(LeaveRequestDTO r)
        {
            string sql = "INSERT INTO LeaveRequest(EmpEmail, TypeID, FromDate, ToDate, Reason, Status) VALUES (@EmpEmail, @TypeID, @FromDate, @ToDate, @Reason, 0)";
            var param = new List<SqlParameter>()
        {
            new SqlParameter("@EmpEmail", r.EmpEmail),
            new SqlParameter("@TypeID", r.TypeID),
            new SqlParameter("@FromDate", r.FromDate),
            new SqlParameter("@ToDate", r.ToDate),
            new SqlParameter("@Reason", r.Reason)
        };
            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }

        public List<LeaveRequestDTO> GetAllRequests()
        {

            List<LeaveRequestDTO> list = new List<LeaveRequestDTO>();
            string sql = "SELECT * FROM LeaveRequest";
            SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new LeaveRequestDTO()
                {
                    RequestID = Convert.ToInt32(reader["RequestID"]),
                    EmpEmail = reader["EmpEmail"].ToString(),
                    TypeID = Convert.ToInt32(reader["TypeID"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    Reason = reader["Reason"].ToString(),
                    Status = Convert.ToInt32(reader["Status"]),
                    ApprovedBy = reader["ApprovedBy"] == DBNull.Value ? null : reader["ApprovedBy"].ToString(),
                    ApproveDate = reader["ApproveDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["ApproveDate"])
                });
            }
            reader.Close();
            return list;
        }

        public LeaveRequestDTO GetById(int requestId)
        {
            LeaveRequestDTO request = null;
            string sql = @"SELECT RequestID, EmpEmail, TypeID, FromDate, ToDate, Reason, 
               Status, ApprovedBy, ApproveDate
               FROM LeaveRequest
               WHERE RequestID = @RequestID";

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@RequestID", requestId)
    };

            SqlDataReader reader = DataProvider.Instance.MyExecuteReader(sql, CommandType.Text, parameters);

            if (reader.Read())
            {
                request = new LeaveRequestDTO
                {
                    RequestID = Convert.ToInt32(reader["RequestID"]),
                    EmpEmail = reader["EmpEmail"].ToString(),
                    TypeID = Convert.ToInt32(reader["TypeID"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    Reason = reader["Reason"].ToString(),
                    Status = Convert.ToInt32(reader["Status"]),
                    ApprovedBy = reader["ApprovedBy"] == DBNull.Value ? null : reader["ApprovedBy"].ToString(),
                    ApproveDate = reader["ApproveDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ApproveDate"])
                };
            }

            reader.Close();
            return request;
        }




        public bool UpdateStatus(int requestId, int status, string approvedBy)
        {
            string sql = "UPDATE LeaveRequest SET Status=@status, ApprovedBy=@approvedBy, ApproveDate=GETDATE() WHERE RequestID=@id";
            var param = new List<SqlParameter>()
        {
            new SqlParameter("@status", status),
            new SqlParameter("@approvedBy", approvedBy),
            new SqlParameter("@id", requestId)
        };
            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }
        public List<LeaveRequestDTO> SearchRequests(string email)
        {
            string sql = @"SELECT R.*
                   FROM LeaveRequest R
                   JOIN Employee E ON R.EmpEmail = E.Email
                   
                   WHERE (@Email = '' OR E.Email LIKE '%' + @Email + '%')";
                    

            var param = new List<SqlParameter>()
    {
        new SqlParameter("@Email", email),
        
    };

            SqlDataReader reader = Instance.MyExecuteReader(sql, CommandType.Text, param);
            List<LeaveRequestDTO> list = new List<LeaveRequestDTO>();

            while(reader.Read())
            {
                LeaveRequestDTO r = new LeaveRequestDTO
                {

                    RequestID = Convert.ToInt32(reader["RequestID"]),
                    EmpEmail = reader["EmpEmail"].ToString(),
                    TypeID = Convert.ToInt32(reader["TypeID"]),
                    FromDate = Convert.ToDateTime(reader["FromDate"]),
                    ToDate = Convert.ToDateTime(reader["ToDate"]),
                    Status = Convert.ToInt32(reader["Status"]),
                    Reason = reader["Reason"].ToString(),
                    ApprovedBy = reader["ApprovedBy"] == DBNull.Value ? null : reader["ApprovedBy"].ToString(),
                    ApproveDate = reader["ApproveDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ApproveDate"])
                };
                list.Add(r);
            }
            reader.Close();
            return list;
        }

        public Dictionary<int, int> GetMonthlyStatistics()
        {
            Dictionary<int, int> stats = new Dictionary<int, int>();
            string sql = @"
        SELECT MONTH(FromDate) AS Month, COUNT(*) AS Count
        FROM LeaveRequest
        WHERE YEAR(FromDate) = YEAR(GETDATE())
        GROUP BY MONTH(FromDate)
        ORDER BY Month";

            SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
            while (reader.Read())
            {
                int month = Convert.ToInt32(reader["Month"]);
                int count = Convert.ToInt32(reader["Count"]);
                stats[month] = count;
            }
            reader.Close();
            return stats;
        }
    }
}
