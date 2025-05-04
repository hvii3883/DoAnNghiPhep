using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class LeaveRequestBL
    {
        private LeaveRequestDL dal = new LeaveRequestDL();
        private EmployeeDL employeeDL = new EmployeeDL();
        EmailService emailService = new EmailService();

        public bool SendRequest(LeaveRequestDTO r) => dal.SendRequest(r);
        public List<LeaveRequestDTO> GetAllRequests() => dal.GetAllRequests();
        public bool UpdateStatus(int id, int status, string approver)
        {
            var result = dal.UpdateStatus(id, status, approver);

            if (result && status == 1)
            {
                var request = dal.GetById(id);
                var emp = employeeDL.GetEmployeeByEmail(request.EmpEmail);
                if (request != null && emp != null)
                {
                    TimeSpan span = request.ToDate - request.FromDate;
                    int days = span.Days + 1;

                    int remaining = emp.TotalLeaveDays - days;
                    if (remaining < 0) remaining = 0;

                    employeeDL.UpdateTotalLeaveDays(emp.Email, remaining);
                }
            }

            return result;
        }
        public Dictionary<int, int> GetMonthlyStatistics() => dal.GetMonthlyStatistics();

      
        public List<LeaveRequestDTO> SearchRequests(string email)
        {
            return dal.SearchRequests(email);
        }
        public void SendLeaveRequestEmail(string email, DateTime from, DateTime to,bool sendEmail)
        {
            if (sendEmail )
            {
                // Gọi DAL để lấy tên nhân viên
                var emp = employeeDL.GetEmployeeByEmail(email);
                if (emp != null)
                {
                    string subject = "Xác nhận đăng ký nghỉ phép";
                    string body = $"Chào {emp.FullName},\nBạn đã đăng ký nghỉ từ {from:dd/MM/yyyy} đến {to:dd/MM/yyyy}.";
                    emailService.SendEmail(emp.Email, subject, body);
                }
            }
        }
    }

}

