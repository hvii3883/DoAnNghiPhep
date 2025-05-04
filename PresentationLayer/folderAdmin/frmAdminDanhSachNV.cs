using BusinessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer.folderAdmin
{
    public partial class frmAdminDanhSachNV : Form
    {
        private EmployeeBL employeeBL = new EmployeeBL();
        private AccountBL accountBL = new AccountBL();
        public frmAdminDanhSachNV()
        {
            InitializeComponent();
            InitDataGridView();
            LoadDanhSachNhanVien();
        }
        private void InitDataGridView()
        {
            dgvDSNV.Columns.Clear();
            dgvDSNV.AutoGenerateColumns = false;
            dgvDSNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSNV.MultiSelect = false;
            dgvDSNV.AllowUserToAddRows = false;

            dgvDSNV.Columns.Add("Email", "Email");
            dgvDSNV.Columns.Add("FullName", "Họ Tên");
            dgvDSNV.Columns.Add("TotalLeaveDays", "Ngày Nghỉ");
        }
        private LeaveRequestBL leaveRequestBL = new LeaveRequestBL();

        public void LoadDanhSachNhanVien()
        {
                dgvDSNV.Rows.Clear();
                List<EmployeeDTO> employees = employeeBL.GetAll();

                foreach (var emp in employees)
                {
                    var approvedRequests = leaveRequestBL.SearchRequests(emp.Email)
                        .Where(r => r.Status == 1) // 1 = Đã duyệt
                        .ToList();

                    int totalUsed = 0;

                    foreach (var req in approvedRequests)
                    {
                        TimeSpan span = req.ToDate - req.FromDate;
                        int days = span.Days + 1; // +1 vì bao gồm cả ngày cuối
                        totalUsed += days;
                    }

                    int totalLeaveDays = emp.TotalLeaveDays;
                    int remainingDays = totalLeaveDays - totalUsed;

                    dgvDSNV.Rows.Add(emp.Email, emp.FullName, totalLeaveDays, totalUsed, remainingDays);
                }
            }

        private void ClearForm()
        {
            txtEmail.Clear();
            txtHoTen.Clear();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSNV.Rows[e.RowIndex];
                txtEmail.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            foreach (DataGridViewRow row in dgvDSNV.Rows)
            {
                if (row.Cells["Email"].Value.ToString().Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Email đã tồn tại.");
                    return;
                }
            }

            AccountDTO account = new AccountDTO { Email = email, Password = "123", Role = 2 };
            if (!accountBL.AddAccount(account))
            {
                MessageBox.Show("Thêm tài khoản thất bại.");
                return;
            }

            EmployeeDTO employee = new EmployeeDTO
            {
                Email = email,
                FullName = hoTen,
                TotalLeaveDays = 12 // mặc định là 12 ngày nghỉ
            };

            if (employeeBL.AddEmployee(employee))
            {
                LoadDanhSachNhanVien(); // Tải lại toàn bộ danh sách thay vì thêm thủ công
                MessageBox.Show("Thêm nhân viên thành công.");
                ClearForm();
            }
            else
            {
                accountBL.DeleteAccount(email);
                MessageBox.Show("Thêm nhân viên thất bại.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAdminDanhSachNV_Load(object sender, EventArgs e)
        {

        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            string email = dgvDSNV.CurrentRow.Cells["Email"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa {email}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            if ( employeeBL.DeleteEmployee(email)&& accountBL.DeleteAccount(email) )
            {
                dgvDSNV.Rows.Remove(dgvDSNV.CurrentRow);
                MessageBox.Show("Xóa thành công.");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật.");
                return;
            }

            string email = txtEmail.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            EmployeeDTO updated = new EmployeeDTO { Email = email, FullName = hoTen };
            if (employeeBL.UpdateEmployee(updated))
            {
                dgvDSNV.CurrentRow.Cells["FullName"].Value = hoTen;
                MessageBox.Show("Cập nhật thành công.");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }


        private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDSNV.Rows[e.RowIndex];
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtHoTen.Text = row.Cells["FullName"].Value.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
