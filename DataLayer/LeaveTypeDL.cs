using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace DataLayer
{
    public class LeaveTypeDL: DataProvider
    {
        public List<LeaveTypeDTO> GetAll()
        {
            List<LeaveTypeDTO> list = new List<LeaveTypeDTO>();
            string sql = "SELECT * FROM LeaveType";
            SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new LeaveTypeDTO()
                {
                    TypeID = Convert.ToInt32(reader["TypeID"]),
                    TypeName = reader["TypeName"].ToString()
                });
            }
            reader.Close();
            return list;
        }
        public bool Update(LeaveTypeDTO lt)
        {
            string sql = "UPDATE LeaveType SET TypeName = @name WHERE TypeID = @id";
            List<SqlParameter> parameters = new List<SqlParameter>
{
    new SqlParameter("@name", lt.TypeName),
    new SqlParameter("@id", lt.TypeID)
};

            return DataProvider.Instance.MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }

        public bool Add(LeaveTypeDTO type)
        {
            string sql = "INSERT INTO LeaveType(TypeName) VALUES(@TypeName)";
            var param = new List<SqlParameter>()
        {
            new SqlParameter("@TypeName", type.TypeName)
        };
            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM LeaveType WHERE TypeID=@id";
            var param = new List<SqlParameter>()
        {
            new SqlParameter("@id", id)
        };
            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }
    }
}
