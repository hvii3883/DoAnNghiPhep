using DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.folderEmployee
{
    public partial class frmEmployeeThongKe : Form
    {
        public string logEmail;
        public frmEmployeeThongKe(string email)
        {
            InitializeComponent();
            logEmail = email;
        }
        private void LoadLeaveInfo()
        {
            try
            {
                int defaultLeaveDays = 12;

                // Lấy thông tin nhân viên
                EmployeeBL empBL = new EmployeeBL();
                var emp = empBL.GetByEmail(logEmail);

                if (emp == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.");
                    return;
                }

                int totalLeaveDays = emp.TotalLeaveDays > 0 ? emp.TotalLeaveDays : defaultLeaveDays;

                // Hiển thị thông tin nhân viên
                txtName.Text = emp.FullName;
                txtEmail.Text = emp.Email;

                // Lấy danh sách đơn nghỉ phép đã được duyệt
                LeaveRequestBL leaveBL = new LeaveRequestBL();
                var approvedRequests = leaveBL.SearchRequests(logEmail)
                    .Where(r => r.Status == 1) // 1 = Đã duyệt
                    .ToList();

                int totalTaken = 0;

                foreach (var req in approvedRequests)
                {
                    TimeSpan span = req.ToDate - req.FromDate;
                    int days = span.Days + 1;
                    totalTaken += days;
                }

                int remaining = totalLeaveDays - totalTaken;

                // Gán dữ liệu lên giao diện
                txtTong.Text = totalLeaveDays.ToString();
                txtDaNghi.Text = totalTaken.ToString();
                txtNgayCon.Text = remaining.ToString();

                if (remaining <= 3)
                {
                    lbWarning.Text = "Cảnh báo: Sắp hết ngày nghỉ!";
                    lbWarning.ForeColor = Color.Red;
                }
                else
                {
                    lbWarning.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nghỉ phép: " + ex.Message);
            }
        }


        private void frmEmployee1_Load(object sender, EventArgs e)
        {
            LoadLeaveInfo();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            LoadLeaveInfo();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
