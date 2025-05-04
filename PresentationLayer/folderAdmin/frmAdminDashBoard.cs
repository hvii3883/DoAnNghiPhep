using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PresentationLayer.folderAdmin
{
    public partial class frmAdminDashBoard : Form
    {
        private string managerEmail;
        private LeaveRequestBL requestBL = new LeaveRequestBL();
        private LeaveTypeBL typeBL = new LeaveTypeBL();

        private frmAdminDanhSachNV danhSachNVForm;

        public frmAdminDashBoard(string email)
        {
            InitializeComponent();
            managerEmail = email;
            danhSachNVForm = new frmAdminDanhSachNV();
            LoadRequests();
        }
        private void LoadRequests()
        {
            var requests = requestBL.GetAllRequests();
            var list = requests.Select(r => new
            {
                r.RequestID,
                r.EmpEmail,
                r.TypeID,
                r.FromDate,
                r.ToDate,
                r.Reason,
                StatusText = r.Status == 0 ? "Chờ duyệt" : r.Status == 1 ? "Đã duyệt" : "Từ chối",
                r.ApprovedBy,
                ApproveDateText = r.ApproveDate?.ToString("dd/MM/yyyy") ?? ""
            }).ToList();

            dgvRequests.DataSource = list;
        }

            private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
    {
        MessageBox.Show("Vui lòng chọn một đơn cần duyệt.");
        return;
    }

    int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestID"].Value);
    bool success = requestBL.UpdateStatus(requestId, 1, managerEmail); // 1: Approved

    if (success)
    {
        MessageBox.Show("Đã duyệt đơn nghỉ phép.");
        LoadRequests(); // Reload lại danh sách đơn
        danhSachNVForm?.LoadDanhSachNhanVien(); // ✅ Cập nhật lại danh sách nhân viên
    }
    else
    {
        MessageBox.Show("Có lỗi xảy ra khi duyệt đơn.");
    }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn cần từ chối.");
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["RequestID"].Value);
            bool success = requestBL.UpdateStatus(requestId, 2, managerEmail); // 2: Rejected

            if (success)
            {
                MessageBox.Show("Đơn đã bị từ chối.");
                LoadRequests(); // Reload lại danh sách đơn
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi từ chối đơn.");
            }
        }

       
        private void frmAdmin1_Load(object sender, EventArgs e)
        {

        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRequests_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            

            var result = requestBL.SearchRequests(email);
            dgvRequests.DataSource = result;
        }
    }
}
