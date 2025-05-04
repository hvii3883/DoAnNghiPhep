using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferObject;

namespace BusinessLayer
{
    public class EmployeeBL

    {
        private EmployeeDL dal = new EmployeeDL();

        public EmployeeDTO GetByEmail(string email) => dal.GetEmployeeByEmail(email);

        public bool UpdateLeaveDays(string email, int newDays) => dal.UpdateTotalLeaveDays(email, newDays);

        public List<EmployeeDTO> GetAll() => dal.GetAllEmployees();
        public bool AddEmployee(EmployeeDTO employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Email) || string.IsNullOrWhiteSpace(employee.FullName))
                return false;
            if (GetByEmail(employee.Email) != null)
                return false;
            employee.TotalLeaveDays = 12;

            return dal.AddEmployee(employee);
        }

        // Phương thức xóa nhân viên theo email
        public bool DeleteEmployee(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return dal.DeleteEmployee(email);
        }
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(employee.Email) || string.IsNullOrWhiteSpace(employee.FullName))
                return false;

            // Kiểm tra xem nhân viên có tồn tại không
            if (GetByEmail(employee.Email) == null)
                return false;

            return dal.UpdateEmployee(employee);
        }


    }
}

