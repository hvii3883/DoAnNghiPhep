using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.folderEmployee
{
    public partial class frmEmployeeDSNghi : Form
    {
        private string logEmail;
        private LeaveRequestBL requestBL= new LeaveRequestBL();
        public frmEmployeeDSNghi(string logEmail)
        {
            InitializeComponent();
            this.logEmail = logEmail;
        }
        private void LoadHistory()
        {
            int selectedStatus = cbStatus.SelectedIndex - 1; // Tất cả = -1, Chưa duyệt = 0, Đã duyệt = 1, Bị từ chối = 2

            var list = requestBL.SearchRequests(logEmail);

            if (selectedStatus >= 0)
            {
                list = list.Where(r => r.Status == selectedStatus).ToList();
            }

            // Hiển thị trạng thái rõ ràng
            var displayList = list.Select(r => new
            {
                r.FromDate,
                r.ToDate,
                StatusText = r.Status == 0 ? "Chưa duyệt" : r.Status == 1 ? "Đã duyệt" : "Bị từ chối",
                r.Reason,
                r.ApprovedBy,
                r.ApproveDate
            }).ToList();

            dgvHistory.DataSource = displayList;
        }

        private void frmEmployeeDSNghi_Load(object sender, EventArgs e)
        {
            cbStatus.Items.Add("Tất cả");
            cbStatus.Items.Add("Chưa duyệt");
            cbStatus.Items.Add("Đã duyệt");
            cbStatus.Items.Add("Bị từ chối");
            cbStatus.SelectedIndex = 0;
            LoadHistory();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
