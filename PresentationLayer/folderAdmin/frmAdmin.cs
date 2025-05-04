using BusinessLayer;
using PresentationLayer.folderAdmin;
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

namespace PresentationLayer
{
    public partial class frmAdmin : Form
    {
        private string managerEmail;
        private LeaveRequestBL requestBL = new LeaveRequestBL();
        private LeaveTypeBL typeBL = new LeaveTypeBL();

        public frmAdmin(string email)
        {
            InitializeComponent();
            managerEmail = email;
            LoadRequests();
        }
        private void LoadRequests()
        {
            
        }
        private void frmAdmin_Load(object sender, EventArgs e)
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
        private void btnApprove_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadStats()
        {
            
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderAdmin.frmAdminDashBoard frm = new folderAdmin.frmAdminDashBoard(managerEmail);
            AddForm(frm);
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            frmAdmin2 frm= new frmAdmin2();
            AddForm(frm);
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Login login= new Login();
            this.Hide();
            login.Show();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            folderAdmin.frmAdminDanhSachNV frm = new folderAdmin.frmAdminDanhSachNV();
            AddForm(frm);
        }

        private void btnLeaveType_Click(object sender, EventArgs e)
        {
            frmQLLeaveType f= new frmQLLeaveType();
            AddForm(f);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
