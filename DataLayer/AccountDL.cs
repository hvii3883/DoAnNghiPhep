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
    public class AccountDL : DataProvider
    {
        public AccountDTO CheckLogin(string email, string password)
        {
            string sql = "SELECT * FROM Account WHERE Email = @Email AND Password = @Password";

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Email", email),
        new SqlParameter("@Password", password)
    };

            SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, parameters);
            if (reader.Read())
            {
                var acc = new AccountDTO()
                {
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString(),
                    Role = Convert.ToInt32(reader["Role"]),
                };
                reader.Close();
                return acc;
            }
            reader.Close();
            return null;
        }
        public bool AddAccount(AccountDTO account)
        {
            string sql = "INSERT INTO Account (Email, Password, Role) VALUES (@Email, @Password, @Role)";

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Email", account.Email),
        new SqlParameter("@Password", account.Password),
        new SqlParameter("@Role", account.Role)
    };

            try
            {
                int rowsAffected = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return rowsAffected > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount(string email)
        {
            string sql = "DELETE FROM Account WHERE Email = @Email";

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Email", email)
    };

            try
            {
                int rowsAffected = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return rowsAffected > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAccount(AccountDTO account)
        {
            string sql = "UPDATE Account SET Password = @Password, Role = @Role WHERE Email = @Email";

            List<SqlParameter> parameters = new List<SqlParameter>()
    {
        new SqlParameter("@Email", account.Email),
        new SqlParameter("@Password", account.Password),
        new SqlParameter("@Role", account.Role)
    };

            try
            {
                int rowsAffected = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return rowsAffected > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
