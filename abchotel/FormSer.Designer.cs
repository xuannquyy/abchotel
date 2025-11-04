namespace abchotel
{
    partial class FormSer
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "Ăn sáng buffet",
            "150.000",
            "/người"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "Spa / Massage",
            "800.000",
            "/lần"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "3",
            "Thuê xe",
            "1.500.000",
            "/ngày"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "4",
            "Thuê phòng họp",
            "2.000.000",
            "/buổi"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "5",
            "Minibar trong phòng",
            "100.000",
            "/món"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "6",
            "Karaoke / Bar Club",
            "800.000",
            "/giờ"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "7",
            "Giặt ủi",
            "50.000",
            "/kg"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "8",
            "Dịch vụ tổ chức tiệc",
            "2.000.00",
            "/suất"}, -1);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lViewDV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butdangky = new System.Windows.Forms.Button();
            this.txbdongia = new System.Windows.Forms.TextBox();
            this.lbsldv = new System.Windows.Forms.Label();
            this.lbdongia = new System.Windows.Forms.Label();
            this.butthemDV = new System.Windows.Forms.Button();
            this.Làmlammoi = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txbsldv = new System.Windows.Forms.TextBox();
            this.txbhoten = new System.Windows.Forms.TextBox();
            this.lbhoten = new System.Windows.Forms.Label();
            this.txbMphong = new System.Windows.Forms.TextBox();
            this.lbMphong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butxoa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1882, 86);
            this.panel1.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sử dụng dịch vụ và thanh toán";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lViewDV);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 631);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các dịch vụ";
            // 
            // lViewDV
            // 
            this.lViewDV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lViewDV.FullRowSelect = true;
            this.lViewDV.GridLines = true;
            this.lViewDV.HideSelection = false;
            this.lViewDV.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lViewDV.Location = new System.Drawing.Point(6, 54);
            this.lViewDV.Name = "lViewDV";
            this.lViewDV.Size = new System.Drawing.Size(746, 562);
            this.lViewDV.TabIndex = 0;
            this.lViewDV.UseCompatibleStateImageBehavior = false;
            this.lViewDV.View = System.Windows.Forms.View.Details;
            this.lViewDV.SelectedIndexChanged += new System.EventHandler(this.lViewDV_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã dịch vụ";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên dịch vụ";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá(VNĐ)";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn vị tính";
            this.columnHeader4.Width = 125;
            // 
            // butdangky
            // 
            this.butdangky.BackColor = System.Drawing.Color.WhiteSmoke;
            this.butdangky.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.butdangky.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.butdangky.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butdangky.Location = new System.Drawing.Point(1623, 886);
            this.butdangky.Name = "butdangky";
            this.butdangky.Size = new System.Drawing.Size(156, 33);
            this.butdangky.TabIndex = 58;
            this.butdangky.Text = "Đăng ký";
            this.butdangky.UseVisualStyleBackColor = false;
            this.butdangky.Click += new System.EventHandler(this.butdangky_Click);
            // 
            // txbdongia
            // 
            this.txbdongia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbdongia.Location = new System.Drawing.Point(1179, 950);
            this.txbdongia.Name = "txbdongia";
            this.txbdongia.Size = new System.Drawing.Size(211, 30);
            this.txbdongia.TabIndex = 57;
            // 
            // lbsldv
            // 
            this.lbsldv.AutoSize = true;
            this.lbsldv.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsldv.Location = new System.Drawing.Point(1179, 826);
            this.lbsldv.Name = "lbsldv";
            this.lbsldv.Size = new System.Drawing.Size(151, 22);
            this.lbsldv.TabIndex = 56;
            this.lbsldv.Text = "Số lượng dịch vụ:";
            // 
            // lbdongia
            // 
            this.lbdongia.AutoSize = true;
            this.lbdongia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdongia.Location = new System.Drawing.Point(1179, 914);
            this.lbdongia.Name = "lbdongia";
            this.lbdongia.Size = new System.Drawing.Size(79, 22);
            this.lbdongia.TabIndex = 55;
            this.lbdongia.Text = "Đơn giá:";
            // 
            // butthemDV
            // 
            this.butthemDV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.butthemDV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.butthemDV.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.butthemDV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butthemDV.Location = new System.Drawing.Point(602, 838);
            this.butthemDV.Name = "butthemDV";
            this.butthemDV.Size = new System.Drawing.Size(194, 33);
            this.butthemDV.TabIndex = 54;
            this.butthemDV.Text = "Thêm dịch vụ";
            this.butthemDV.UseVisualStyleBackColor = false;
            this.butthemDV.Click += new System.EventHandler(this.butthemDV_Click);
            // 
            // Làmlammoi
            // 
            this.Làmlammoi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Làmlammoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.Làmlammoi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Làmlammoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Làmlammoi.Location = new System.Drawing.Point(1623, 950);
            this.Làmlammoi.Name = "Làmlammoi";
            this.Làmlammoi.Size = new System.Drawing.Size(156, 33);
            this.Làmlammoi.TabIndex = 59;
            this.Làmlammoi.Text = "Làm mới";
            this.Làmlammoi.UseVisualStyleBackColor = false;
            this.Làmlammoi.Click += new System.EventHandler(this.Làmlammoi_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1071, 395);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(799, 395);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách các dịch vụ khách hàng đặt";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(6, 51);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(787, 329);
            this.listBox1.TabIndex = 0;
            // 
            // txbsldv
            // 
            this.txbsldv.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsldv.Location = new System.Drawing.Point(1183, 862);
            this.txbsldv.Name = "txbsldv";
            this.txbsldv.Size = new System.Drawing.Size(211, 30);
            this.txbsldv.TabIndex = 65;
            // 
            // txbhoten
            // 
            this.txbhoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbhoten.Location = new System.Drawing.Point(1403, 305);
            this.txbhoten.Margin = new System.Windows.Forms.Padding(2);
            this.txbhoten.Name = "txbhoten";
            this.txbhoten.Size = new System.Drawing.Size(232, 30);
            this.txbhoten.TabIndex = 64;
            // 
            // lbhoten
            // 
            this.lbhoten.AutoSize = true;
            this.lbhoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhoten.Location = new System.Drawing.Point(1179, 313);
            this.lbhoten.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbhoten.Name = "lbhoten";
            this.lbhoten.Size = new System.Drawing.Size(92, 22);
            this.lbhoten.TabIndex = 63;
            this.lbhoten.Text = "Họ và tên:";
            // 
            // txbMphong
            // 
            this.txbMphong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMphong.Location = new System.Drawing.Point(1403, 240);
            this.txbMphong.Margin = new System.Windows.Forms.Padding(2);
            this.txbMphong.Name = "txbMphong";
            this.txbMphong.Size = new System.Drawing.Size(236, 30);
            this.txbMphong.TabIndex = 62;
            // 
            // lbMphong
            // 
            this.lbMphong.AutoSize = true;
            this.lbMphong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMphong.Location = new System.Drawing.Point(1179, 247);
            this.lbMphong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMphong.Name = "lbMphong";
            this.lbMphong.Size = new System.Drawing.Size(95, 22);
            this.lbMphong.TabIndex = 61;
            this.lbMphong.Text = "Mã Phòng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(1272, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 25);
            this.label4.TabIndex = 60;
            this.label4.Text = "Đăng ký dịch vụ";
            // 
            // butxoa
            // 
            this.butxoa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.butxoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.butxoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.butxoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butxoa.Location = new System.Drawing.Point(1623, 821);
            this.butxoa.Name = "butxoa";
            this.butxoa.Size = new System.Drawing.Size(156, 33);
            this.butxoa.TabIndex = 66;
            this.butxoa.Text = "Xóa";
            this.butxoa.UseVisualStyleBackColor = false;
            this.butxoa.Click += new System.EventHandler(this.butxoa_Click);
            // 
            // FormSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 1002);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butdangky);
            this.Controls.Add(this.txbdongia);
            this.Controls.Add(this.lbsldv);
            this.Controls.Add(this.lbdongia);
            this.Controls.Add(this.butthemDV);
            this.Controls.Add(this.Làmlammoi);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txbsldv);
            this.Controls.Add(this.txbhoten);
            this.Controls.Add(this.lbhoten);
            this.Controls.Add(this.txbMphong);
            this.Controls.Add(this.lbMphong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butxoa);
            this.Name = "FormSer";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lViewDV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button butdangky;
        private System.Windows.Forms.TextBox txbdongia;
        private System.Windows.Forms.Label lbsldv;
        private System.Windows.Forms.Label lbdongia;
        private System.Windows.Forms.Button butthemDV;
        private System.Windows.Forms.Button Làmlammoi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txbsldv;
        private System.Windows.Forms.TextBox txbhoten;
        private System.Windows.Forms.Label lbhoten;
        private System.Windows.Forms.TextBox txbMphong;
        private System.Windows.Forms.Label lbMphong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butxoa;
    }
}