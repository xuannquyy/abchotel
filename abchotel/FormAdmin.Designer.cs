namespace abchotel
{
    partial class FormAdmin
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
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTaiKhoan = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.btxoatk = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btthemmoi = new System.Windows.Forms.Button();
            this.btreset = new System.Windows.Forms.Button();
            this.cbChucVu = new System.Windows.Forms.ComboBox();
            this.labchucvu = new System.Windows.Forms.Label();
            this.txbmail = new System.Windows.Forms.TextBox();
            this.labmail = new System.Windows.Forms.Label();
            this.txbhoten = new System.Windows.Forms.TextBox();
            this.labhoten = new System.Windows.Forms.Label();
            this.txbtendn = new System.Windows.Forms.TextBox();
            this.labtendn = new System.Windows.Forms.Label();
            this.txbmanv = new System.Windows.Forms.TextBox();
            this.labmaNV = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTimkiem = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbmatkhau = new System.Windows.Forms.TextBox();
            this.labmatkhau = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimkiem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Trạng thái";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Họ và tên";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên đăng nhập";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã NV";
            this.columnHeader1.Width = 80;
            // 
            // lvTaiKhoan
            // 
            this.lvTaiKhoan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTaiKhoan.FullRowSelect = true;
            this.lvTaiKhoan.GridLines = true;
            this.lvTaiKhoan.HideSelection = false;
            this.lvTaiKhoan.Location = new System.Drawing.Point(35, 166);
            this.lvTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvTaiKhoan.MultiSelect = false;
            this.lvTaiKhoan.Name = "lvTaiKhoan";
            this.lvTaiKhoan.Size = new System.Drawing.Size(840, 541);
            this.lvTaiKhoan.TabIndex = 13;
            this.lvTaiKhoan.UseCompatibleStateImageBehavior = false;
            this.lvTaiKhoan.View = System.Windows.Forms.View.Details;
            this.lvTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.lvTaiKhoan_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Chức vụ";
            this.columnHeader4.Width = 120;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiem.Location = new System.Drawing.Point(163, 96);
            this.txtTimkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(515, 30);
            this.txtTimkiem.TabIndex = 12;
            this.txtTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimkiem_KeyDown);
            // 
            // btxoatk
            // 
            this.btxoatk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxoatk.Location = new System.Drawing.Point(228, 663);
            this.btxoatk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btxoatk.Name = "btxoatk";
            this.btxoatk.Size = new System.Drawing.Size(195, 44);
            this.btxoatk.TabIndex = 25;
            this.btxoatk.Text = "XÓA TÀI KHOẢN";
            this.btxoatk.UseVisualStyleBackColor = true;
            this.btxoatk.Click += new System.EventHandler(this.btxoatk_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(437, 663);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(155, 44);
            this.btnHuy.TabIndex = 24;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btthemmoi
            // 
            this.btthemmoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btthemmoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthemmoi.ForeColor = System.Drawing.SystemColors.Control;
            this.btthemmoi.Location = new System.Drawing.Point(20, 663);
            this.btthemmoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btthemmoi.Name = "btthemmoi";
            this.btthemmoi.Size = new System.Drawing.Size(189, 44);
            this.btthemmoi.TabIndex = 23;
            this.btthemmoi.Text = "THÊM MỚI";
            this.btthemmoi.UseVisualStyleBackColor = false;
            this.btthemmoi.Click += new System.EventHandler(this.btthemmoi_Click);
            // 
            // btreset
            // 
            this.btreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btreset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btreset.ForeColor = System.Drawing.SystemColors.Control;
            this.btreset.Location = new System.Drawing.Point(196, 559);
            this.btreset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btreset.Name = "btreset";
            this.btreset.Size = new System.Drawing.Size(245, 44);
            this.btreset.TabIndex = 22;
            this.btreset.Text = "RESET MẬT KHẨU";
            this.btreset.UseVisualStyleBackColor = false;
            this.btreset.Click += new System.EventHandler(this.btreset_Click);
            // 
            // cbChucVu
            // 
            this.cbChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChucVu.FormattingEnabled = true;
            this.cbChucVu.Location = new System.Drawing.Point(217, 433);
            this.cbChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChucVu.Name = "cbChucVu";
            this.cbChucVu.Size = new System.Drawing.Size(348, 30);
            this.cbChucVu.TabIndex = 19;
            // 
            // labchucvu
            // 
            this.labchucvu.AutoSize = true;
            this.labchucvu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labchucvu.Location = new System.Drawing.Point(28, 439);
            this.labchucvu.Name = "labchucvu";
            this.labchucvu.Size = new System.Drawing.Size(105, 26);
            this.labchucvu.TabIndex = 18;
            this.labchucvu.Text = "Chức vụ:";
            // 
            // txbmail
            // 
            this.txbmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmail.Location = new System.Drawing.Point(217, 354);
            this.txbmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmail.Name = "txbmail";
            this.txbmail.Size = new System.Drawing.Size(348, 30);
            this.txbmail.TabIndex = 17;
            // 
            // labmail
            // 
            this.labmail.AutoSize = true;
            this.labmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labmail.Location = new System.Drawing.Point(28, 359);
            this.labmail.Name = "labmail";
            this.labmail.Size = new System.Drawing.Size(81, 26);
            this.labmail.TabIndex = 16;
            this.labmail.Text = "Email:";
            // 
            // txbhoten
            // 
            this.txbhoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbhoten.Location = new System.Drawing.Point(217, 287);
            this.txbhoten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbhoten.Name = "txbhoten";
            this.txbhoten.Size = new System.Drawing.Size(348, 30);
            this.txbhoten.TabIndex = 15;
            // 
            // labhoten
            // 
            this.labhoten.AutoSize = true;
            this.labhoten.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labhoten.Location = new System.Drawing.Point(28, 292);
            this.labhoten.Name = "labhoten";
            this.labhoten.Size = new System.Drawing.Size(118, 26);
            this.labhoten.TabIndex = 14;
            this.labhoten.Text = "Họ và tên:";
            // 
            // txbtendn
            // 
            this.txbtendn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtendn.Location = new System.Drawing.Point(217, 153);
            this.txbtendn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbtendn.Name = "txbtendn";
            this.txbtendn.Size = new System.Drawing.Size(348, 30);
            this.txbtendn.TabIndex = 13;
            // 
            // labtendn
            // 
            this.labtendn.AutoSize = true;
            this.labtendn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labtendn.Location = new System.Drawing.Point(25, 154);
            this.labtendn.Name = "labtendn";
            this.labtendn.Size = new System.Drawing.Size(172, 26);
            this.labtendn.TabIndex = 12;
            this.labtendn.Text = "Tên đăng nhập:";
            // 
            // txbmanv
            // 
            this.txbmanv.Enabled = false;
            this.txbmanv.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmanv.Location = new System.Drawing.Point(217, 96);
            this.txbmanv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmanv.Name = "txbmanv";
            this.txbmanv.Size = new System.Drawing.Size(348, 30);
            this.txbmanv.TabIndex = 11;
            // 
            // labmaNV
            // 
            this.labmaNV.AutoSize = true;
            this.labmaNV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labmaNV.Location = new System.Drawing.Point(25, 101);
            this.labmaNV.Name = "labmaNV";
            this.labmaNV.Size = new System.Drawing.Size(93, 26);
            this.labmaNV.TabIndex = 10;
            this.labmaNV.Text = "Mã NV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(43, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "DANH SÁCH TÀI KHOẢN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(35, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "CHI TIẾT TÀI KHOẢN";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbTimkiem);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lvTaiKhoan);
            this.panel2.Controls.Add(this.txtTimkiem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(899, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 761);
            this.panel2.TabIndex = 6;
            // 
            // pbTimkiem
            // 
            this.pbTimkiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTimkiem.Image = global::abchotel.Properties.Resources.icons8_search_100;
            this.pbTimkiem.Location = new System.Drawing.Point(680, 96);
            this.pbTimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbTimkiem.Name = "pbTimkiem";
            this.pbTimkiem.Size = new System.Drawing.Size(39, 32);
            this.pbTimkiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTimkiem.TabIndex = 15;
            this.pbTimkiem.TabStop = false;
            this.pbTimkiem.Click += new System.EventHandler(this.pbTimkiem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tìm kiếm:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txbmatkhau);
            this.panel1.Controls.Add(this.labmatkhau);
            this.panel1.Controls.Add(this.btxoatk);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btthemmoi);
            this.panel1.Controls.Add(this.btreset);
            this.panel1.Controls.Add(this.cbChucVu);
            this.panel1.Controls.Add(this.labchucvu);
            this.panel1.Controls.Add(this.txbmail);
            this.panel1.Controls.Add(this.labmail);
            this.panel1.Controls.Add(this.txbhoten);
            this.panel1.Controls.Add(this.labhoten);
            this.panel1.Controls.Add(this.txbtendn);
            this.panel1.Controls.Add(this.labtendn);
            this.panel1.Controls.Add(this.txbmanv);
            this.panel1.Controls.Add(this.labmaNV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(228, 160);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 761);
            this.panel1.TabIndex = 5;
            // 
            // txbmatkhau
            // 
            this.txbmatkhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbmatkhau.Location = new System.Drawing.Point(217, 217);
            this.txbmatkhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbmatkhau.Name = "txbmatkhau";
            this.txbmatkhau.Size = new System.Drawing.Size(348, 30);
            this.txbmatkhau.TabIndex = 27;
            // 
            // labmatkhau
            // 
            this.labmatkhau.AutoSize = true;
            this.labmatkhau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labmatkhau.Location = new System.Drawing.Point(25, 222);
            this.labmatkhau.Name = "labmatkhau";
            this.labmatkhau.Size = new System.Drawing.Size(120, 26);
            this.labmatkhau.TabIndex = 26;
            this.labmatkhau.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1924, 134);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ TÀI KHOẢN HỆ THỐNG (ADMIN)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimkiem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvTaiKhoan;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Button btxoatk;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btthemmoi;
        private System.Windows.Forms.Button btreset;
        private System.Windows.Forms.ComboBox cbChucVu;
        private System.Windows.Forms.Label labchucvu;
        private System.Windows.Forms.TextBox txbmail;
        private System.Windows.Forms.Label labmail;
        private System.Windows.Forms.TextBox txbhoten;
        private System.Windows.Forms.Label labhoten;
        private System.Windows.Forms.TextBox txbtendn;
        private System.Windows.Forms.Label labtendn;
        private System.Windows.Forms.TextBox txbmanv;
        private System.Windows.Forms.Label labmaNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbmatkhau;
        private System.Windows.Forms.Label labmatkhau;
        private System.Windows.Forms.PictureBox pbTimkiem;
    }
}