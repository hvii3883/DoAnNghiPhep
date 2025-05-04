namespace PresentationLayer.folderEmployee
{
    partial class frmEmployeeThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbTotalDays = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbFullName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNgayCon = new System.Windows.Forms.TextBox();
            this.txtDaNghi = new System.Windows.Forms.TextBox();
            this.lbDaysRemaining = new System.Windows.Forms.Label();
            this.lbDaysTaken = new System.Windows.Forms.Label();
            this.lbWarning = new System.Windows.Forms.Label();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTong);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lbTotalDays);
            this.groupBox1.Controls.Add(this.lbEmail);
            this.groupBox1.Controls.Add(this.lbFullName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(45, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cá nhân: ";
            // 
            // txtTong
            // 
            this.txtTong.Location = new System.Drawing.Point(26, 209);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(373, 30);
            this.txtTong.TabIndex = 6;
            this.txtTong.TextChanged += new System.EventHandler(this.txtTong_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(107, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(292, 30);
            this.txtEmail.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(292, 30);
            this.txtName.TabIndex = 2;
            // 
            // lbTotalDays
            // 
            this.lbTotalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDays.Location = new System.Drawing.Point(21, 173);
            this.lbTotalDays.Name = "lbTotalDays";
            this.lbTotalDays.Size = new System.Drawing.Size(195, 33);
            this.lbTotalDays.TabIndex = 2;
            this.lbTotalDays.Text = "Tổng số ngày nghỉ: ";
            // 
            // lbEmail
            // 
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(21, 107);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(100, 33);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "Email:";
            // 
            // lbFullName
            // 
            this.lbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.Location = new System.Drawing.Point(21, 43);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(100, 33);
            this.lbFullName.TabIndex = 0;
            this.lbFullName.Text = "Họ tên:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNgayCon);
            this.groupBox2.Controls.Add(this.txtDaNghi);
            this.groupBox2.Controls.Add(this.lbDaysRemaining);
            this.groupBox2.Controls.Add(this.lbDaysTaken);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(548, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 275);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tình hình nghỉ phép";
            // 
            // txtNgayCon
            // 
            this.txtNgayCon.Location = new System.Drawing.Point(30, 188);
            this.txtNgayCon.Name = "txtNgayCon";
            this.txtNgayCon.Size = new System.Drawing.Size(346, 30);
            this.txtNgayCon.TabIndex = 5;
            // 
            // txtDaNghi
            // 
            this.txtDaNghi.Location = new System.Drawing.Point(30, 92);
            this.txtDaNghi.Name = "txtDaNghi";
            this.txtDaNghi.Size = new System.Drawing.Size(346, 30);
            this.txtDaNghi.TabIndex = 4;
            // 
            // lbDaysRemaining
            // 
            this.lbDaysRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDaysRemaining.Location = new System.Drawing.Point(25, 141);
            this.lbDaysRemaining.Name = "lbDaysRemaining";
            this.lbDaysRemaining.Size = new System.Drawing.Size(198, 33);
            this.lbDaysRemaining.TabIndex = 4;
            this.lbDaysRemaining.Text = "Số ngày nghỉ còn lại: ";
            // 
            // lbDaysTaken
            // 
            this.lbDaysTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDaysTaken.Location = new System.Drawing.Point(25, 43);
            this.lbDaysTaken.Name = "lbDaysTaken";
            this.lbDaysTaken.Size = new System.Drawing.Size(213, 33);
            this.lbDaysTaken.TabIndex = 3;
            this.lbDaysTaken.Text = "Số ngày đã nghỉ:";
            // 
            // lbWarning
            // 
            this.lbWarning.BackColor = System.Drawing.SystemColors.Control;
            this.lbWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWarning.Location = new System.Drawing.Point(268, 78);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(299, 23);
            this.lbWarning.TabIndex = 2;
            this.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefesh
            // 
            this.btnRefesh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefesh.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRefesh.Location = new System.Drawing.Point(427, 401);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(172, 57);
            this.btnRefesh.TabIndex = 3;
            this.btnRefesh.Text = "LÀM MỚI";
            this.btnRefesh.UseVisualStyleBackColor = false;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1019, 82);
            this.label1.TabIndex = 5;
            this.label1.Text = "THỐNG KÊ NGHỈ PHÉP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEmployeeThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmployeeThongKe";
            this.Text = "frmEmployee1";
            this.Load += new System.EventHandler(this.frmEmployee1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTotalDays;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbDaysRemaining;
        private System.Windows.Forms.Label lbDaysTaken;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNgayCon;
        private System.Windows.Forms.TextBox txtDaNghi;
        private System.Windows.Forms.Label lbWarning;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Label label1;
    }
}