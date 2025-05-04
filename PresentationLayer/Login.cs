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
using PresentationLayer.folderAdmin;
using PresentationLayer.folderEmployee;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        private AccountBL accountBL = new AccountBL();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            var acc = accountBL.Login(email, password);
            if (acc != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                this.Hide();

                if (acc.Role == 1)
                {
                    frmAdmin f = new frmAdmin(acc.Email);
                    f.Show();
                }
                else if (acc.Role == 2)
                {
                    {
                        frmEmployee_ f = new frmEmployee_(acc.Email);
                        f.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Lỗi");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

