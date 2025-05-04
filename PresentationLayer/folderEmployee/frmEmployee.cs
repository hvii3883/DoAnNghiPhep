using BusinessLayer;
using DataTransferObject;
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
using PresentationLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace PresentationLayer
{
    public partial class frmEmployee : Form
    {
        private string empEmail;
        private LeaveTypeBL typeBL = new LeaveTypeBL();
        private LeaveRequestBL requestBL = new LeaveRequestBL();

        public frmEmployee(string email)
        {
            InitializeComponent();
            
            empEmail = email;
            LoadLeaveTypes();
        }
        private void LoadLeaveTypes()
        {
            var types = typeBL.GetAll();
            if (types == null || types.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu loại nghỉ phép!", "Thông báo");
                return;
            }

            
            cbLeaveType.DataSource = types;
            cbLeaveType.DisplayMember = "TypeName";
            cbLeaveType.ValueMember = "TypeID";
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadLeaveTypes();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            LeaveRequestDTO r = new LeaveRequestDTO()
            {
                EmpEmail = empEmail,
                TypeID = (int)cbLeaveType.SelectedValue,
                FromDate = dtFrom.Value,
                ToDate = dtTo.Value,
                Reason = txtReason.Text
                 
        };
            DateTime from = dtFrom.Value;
            DateTime to = dtTo.Value;
            bool guiEmail = chkSendEmail.Checked;

            requestBL.SendLeaveRequestEmail(empEmail, from, to, guiEmail);
            if (dtFrom.Value.Date >= dtTo.Value.Date)
            {
                MessageBox.Show("Ngày nghỉ kết thúc phải sau ngày nghỉ bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (requestBL.SendRequest(r))
            {
                MessageBox.Show("Gửi đơn nghỉ phép thành công!");
            }
            else
            {
                MessageBox.Show("Gửi thất bại!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void cbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
