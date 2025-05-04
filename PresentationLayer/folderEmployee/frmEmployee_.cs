using BusinessLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PresentationLayer.folderEmployee
{
    public partial class frmEmployee_ : Form
    {
        private string empEmail;
        private LeaveTypeBL typeBL = new LeaveTypeBL();
        private LeaveRequestBL requestBL = new LeaveRequestBL();
        public frmEmployee_(string email)
        {
            InitializeComponent();
            empEmail = email;
            
        }

        private void cbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddForm(Form form)
        {
            form.TopLevel = false;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            frmEmployeeDKy f= new frmEmployeeDKy(empEmail);
            AddForm(f);
        }

        private void frmEmployeeDashboard_Load(object sender, EventArgs e)
        {
            
           
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmEmployeeThongKe f= new frmEmployeeThongKe(empEmail);
            AddForm(f);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login= new  Login();
            this.Hide();
            login.Show();
        }

        private void btnNghiNhom_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmEmployeeDSNghi f= new frmEmployeeDSNghi(empEmail);
            AddForm(f);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
