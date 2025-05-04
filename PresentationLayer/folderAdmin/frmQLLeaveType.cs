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
using DataTransferObject;

namespace PresentationLayer.folderAdmin
{
    public partial class frmQLLeaveType : Form
    {
        LeaveTypeBL leaveTypeBL = new LeaveTypeBL();

        public frmQLLeaveType()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadData()
        {
            dgvLeaveType.DataSource = leaveTypeBL.GetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LeaveTypeDTO lt = new LeaveTypeDTO { TypeName = txtTypeName.Text };
            if (leaveTypeBL.Add(lt))
            {
                MessageBox.Show("Đã thêm loại nghỉ phép!");
                LoadData();
            }
        }

        private void frmQLLeaveType_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLeaveType.CurrentRow != null)
            {
                LeaveTypeDTO lt = new LeaveTypeDTO
                {
                    TypeID = Convert.ToInt32(dgvLeaveType.CurrentRow.Cells["TypeID"].Value),
                    TypeName = txtTypeName.Text
                };
                if (leaveTypeBL.Update(lt))
                {
                    MessageBox.Show("Đã cập nhật loại nghỉ phép!");
                    LoadData();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLeaveType.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvLeaveType.CurrentRow.Cells["TypeID"].Value);
                if (leaveTypeBL.Delete(id))
                {
                    MessageBox.Show("Đã xoá loại nghỉ phép!");
                    LoadData();
                }
            }
        }
    }
}
