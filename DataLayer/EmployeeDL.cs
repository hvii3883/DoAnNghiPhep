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
    public class EmployeeDL: DataProvider
    {
        public EmployeeDTO GetEmployeeByEmail(string email)
        {
            string sql = "SELECT * FROM Employee WHERE Email = @Email";
        var param = new List<SqlParameter>()
        {
            new SqlParameter("@Email", email)
        };

        SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, param);
        if (reader.Read())
        {
            var emp = new EmployeeDTO()
            {
                Email = reader["Email"].ToString(),
                FullName = reader["FullName"].ToString(),
                TotalLeaveDays = Convert.ToInt32(reader["TotalLeaveDays"])
            };
        reader.Close();
            return emp;
        }
    reader.Close();
        return null;
    }
        public bool AddEmployee(EmployeeDTO employee)
        {
            string sql = "INSERT INTO Employee (Email, FullName, TotalLeaveDays) VALUES (@Email, @FullName, @TotalLeaveDays)";
            var param = new List<SqlParameter>()
            {
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@TotalLeaveDays", employee.TotalLeaveDays)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }

        // Phương thức xóa nhân viên theo email
        public bool DeleteEmployee(string email)
        {
            string sql = "DELETE FROM Employee WHERE Email = @Email";
            var param = new List<SqlParameter>()
            {
                new SqlParameter("@Email", email)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            string sql = "UPDATE Employee SET FullName = @FullName, TotalLeaveDays = @TotalLeaveDays WHERE Email = @Email";
            var param = new List<SqlParameter>()
            {
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@TotalLeaveDays", employee.TotalLeaveDays),
                new SqlParameter("@Email", employee.Email)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }

        public bool UpdateTotalLeaveDays(string email, int newDays)
{
    string sql = "UPDATE Employee SET TotalLeaveDays = @Days WHERE Email = @Email";
    var param = new List<SqlParameter>()
        {
            new SqlParameter("@Days", newDays),
            new SqlParameter("@Email", email)
        };
    return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
}

        public List<EmployeeDTO> GetAllEmployees()
{
    List<EmployeeDTO> list = new List<EmployeeDTO>();
    string sql = "SELECT * FROM Employee";
    SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);

    while (reader.Read())
    {
        list.Add(new EmployeeDTO()
        {
            Email = reader["Email"].ToString(),
            FullName = reader["FullName"].ToString(),
            TotalLeaveDays = Convert.ToInt32(reader["TotalLeaveDays"])
        });
    }
    reader.Close();
    return list;
}
    }
}
