namespace abchotel
{
    partial class FormInvoice
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
            this.lblql = new System.Windows.Forms.Label();
            this.Tongtinkh = new System.Windows.Forms.Panel();
            this.gbthongtin = new System.Windows.Forms.GroupBox();
            this.cboSoPhong = new System.Windows.Forms.ComboBox();
            this.lblChiPhiPhong = new System.Windows.Forms.Label();
            this.lblDongiaphong = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoaiPhong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgayTra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNgayNhan = new System.Windows.Forms.TextBox();
            this.lblsongay = new System.Windows.Forms.Label();
            this.lbltenkh = new System.Windows.Forms.Label();
            this.lblphong = new System.Windows.Forms.Label();
            this.lbltong = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.ThongTinKhachHang = new System.Windows.Forms.Label();
            this.btnpdf = new System.Windows.Forms.Button();
            this.btnexcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblChiPhiDichVu = new System.Windows.Forms.Label();
            this.dgvChiTietDichVu = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTienDichVu = new System.Windows.Forms.TextBox();
            this.txtTienPhong = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblgiamgia = new System.Windows.Forms.Label();
            this.lbltiendv = new System.Windows.Forms.Label();
            this.lbltienphong = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Tongtinkh.SuspendLayout();
            this.gbthongtin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDichVu)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblql
            // 
            this.lblql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblql.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblql.ForeColor = System.Drawing.Color.White;
            this.lblql.Location = new System.Drawing.Point(-5, -1);
            this.lblql.Name = "lblql";
            this.lblql.Size = new System.Drawing.Size(2180, 112);
            this.lblql.TabIndex = 0;
            this.lblql.Text = "Quản Lý Hóa Đơn ";
            this.lblql.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tongtinkh
            // 
            this.Tongtinkh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tongtinkh.Controls.Add(this.gbthongtin);
            this.Tongtinkh.Controls.Add(this.ThongTinKhachHang);
            this.Tongtinkh.Location = new System.Drawing.Point(83, 241);
            this.Tongtinkh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tongtinkh.Name = "Tongtinkh";
            this.Tongtinkh.Size = new System.Drawing.Size(615, 627);
            this.Tongtinkh.TabIndex = 2;
            // 
            // gbthongtin
            // 
            this.gbthongtin.Controls.Add(this.cboSoPhong);
            this.gbthongtin.Controls.Add(this.lblChiPhiPhong);
            this.gbthongtin.Controls.Add(this.lblDongiaphong);
            this.gbthongtin.Controls.Add(this.label6);
            this.gbthongtin.Controls.Add(this.txtLoaiPhong);
            this.gbthongtin.Controls.Add(this.label4);
            this.gbthongtin.Controls.Add(this.txtNgayTra);
            this.gbthongtin.Controls.Add(this.label1);
            this.gbthongtin.Controls.Add(this.txtNgayNhan);
            this.gbthongtin.Controls.Add(this.lblsongay);
            this.gbthongtin.Controls.Add(this.lbltenkh);
            this.gbthongtin.Controls.Add(this.lblphong);
            this.gbthongtin.Controls.Add(this.lbltong);
            this.gbthongtin.Controls.Add(this.txtTenKhachHang);
            this.gbthongtin.Location = new System.Drawing.Point(9, 76);
            this.gbthongtin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbthongtin.Name = "gbthongtin";
            this.gbthongtin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbthongtin.Size = new System.Drawing.Size(595, 528);
            this.gbthongtin.TabIndex = 14;
            this.gbthongtin.TabStop = false;
            // 
            // cboSoPhong
            // 
            this.cboSoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSoPhong.FormattingEnabled = true;
            this.cboSoPhong.Location = new System.Drawing.Point(248, 38);
            this.cboSoPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSoPhong.Name = "cboSoPhong";
            this.cboSoPhong.Size = new System.Drawing.Size(332, 37);
            this.cboSoPhong.TabIndex = 21;
            this.cboSoPhong.SelectedIndexChanged += new System.EventHandler(this.cboSoPhong_SelectedIndexChanged);
            // 
            // lblChiPhiPhong
            // 
            this.lblChiPhiPhong.BackColor = System.Drawing.SystemColors.Control;
            this.lblChiPhiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblChiPhiPhong.ForeColor = System.Drawing.Color.Navy;
            this.lblChiPhiPhong.Location = new System.Drawing.Point(231, 406);
            this.lblChiPhiPhong.Name = "lblChiPhiPhong";
            this.lblChiPhiPhong.Size = new System.Drawing.Size(343, 36);
            this.lblChiPhiPhong.TabIndex = 20;
            this.lblChiPhiPhong.Text = "0 VNĐ";
            this.lblChiPhiPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDongiaphong
            // 
            this.lblDongiaphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDongiaphong.Location = new System.Drawing.Point(284, 375);
            this.lblDongiaphong.Name = "lblDongiaphong";
            this.lblDongiaphong.Size = new System.Drawing.Size(285, 22);
            this.lblDongiaphong.TabIndex = 19;
            this.lblDongiaphong.Text = "Đơn giá x Số đêm";
            this.lblDongiaphong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(380, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Chi phí phòng";
            // 
            // txtLoaiPhong
            // 
            this.txtLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtLoaiPhong.Location = new System.Drawing.Point(248, 263);
            this.txtLoaiPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoaiPhong.Multiline = true;
            this.txtLoaiPhong.Name = "txtLoaiPhong";
            this.txtLoaiPhong.Size = new System.Drawing.Size(325, 34);
            this.txtLoaiPhong.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(12, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Loại phòng ";
            // 
            // txtNgayTra
            // 
            this.txtNgayTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayTra.Location = new System.Drawing.Point(356, 212);
            this.txtNgayTra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayTra.Multiline = true;
            this.txtNgayTra.Name = "txtNgayTra";
            this.txtNgayTra.Size = new System.Drawing.Size(217, 29);
            this.txtNgayTra.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(279, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Đến ";
            // 
            // txtNgayNhan
            // 
            this.txtNgayNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNgayNhan.Location = new System.Drawing.Point(64, 212);
            this.txtNgayNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayNhan.Multiline = true;
            this.txtNgayNhan.Name = "txtNgayNhan";
            this.txtNgayNhan.Size = new System.Drawing.Size(196, 29);
            this.txtNgayNhan.TabIndex = 13;
            // 
            // lblsongay
            // 
            this.lblsongay.AutoSize = true;
            this.lblsongay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsongay.Location = new System.Drawing.Point(5, 212);
            this.lblsongay.Name = "lblsongay";
            this.lblsongay.Size = new System.Drawing.Size(42, 29);
            this.lblsongay.TabIndex = 10;
            this.lblsongay.Text = "Từ";
            // 
            // lbltenkh
            // 
            this.lbltenkh.AutoSize = true;
            this.lbltenkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltenkh.Location = new System.Drawing.Point(9, 102);
            this.lbltenkh.Name = "lbltenkh";
            this.lbltenkh.Size = new System.Drawing.Size(198, 29);
            this.lbltenkh.TabIndex = 2;
            this.lbltenkh.Text = "Tên khách hàng";
            // 
            // lblphong
            // 
            this.lblphong.AutoSize = true;
            this.lblphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblphong.Location = new System.Drawing.Point(15, 43);
            this.lblphong.Name = "lblphong";
            this.lblphong.Size = new System.Drawing.Size(132, 29);
            this.lblphong.TabIndex = 3;
            this.lblphong.Text = "Số phòng ";
            // 
            // lbltong
            // 
            this.lbltong.AutoSize = true;
            this.lbltong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltong.Location = new System.Drawing.Point(12, 161);
            this.lbltong.Name = "lbltong";
            this.lbltong.Size = new System.Drawing.Size(152, 29);
            this.lbltong.TabIndex = 5;
            this.lbltong.Text = "Thời gian ở ";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenKhachHang.Location = new System.Drawing.Point(248, 97);
            this.txtTenKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenKhachHang.Multiline = true;
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(332, 34);
            this.txtTenKhachHang.TabIndex = 8;
            // 
            // ThongTinKhachHang
            // 
            this.ThongTinKhachHang.AutoSize = true;
            this.ThongTinKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ThongTinKhachHang.Location = new System.Drawing.Point(72, 11);
            this.ThongTinKhachHang.Name = "ThongTinKhachHang";
            this.ThongTinKhachHang.Size = new System.Drawing.Size(410, 42);
            this.ThongTinKhachHang.TabIndex = 0;
            this.ThongTinKhachHang.Text = "Thông tin khách hàng ";
            // 
            // btnpdf
            // 
            this.btnpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnpdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnpdf.ForeColor = System.Drawing.Color.White;
            this.btnpdf.Location = new System.Drawing.Point(359, 537);
            this.btnpdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(185, 57);
            this.btnpdf.TabIndex = 13;
            this.btnpdf.Text = "Xuất PDF";
            this.btnpdf.UseVisualStyleBackColor = false;
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnexcel
            // 
            this.btnexcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnexcel.ForeColor = System.Drawing.Color.White;
            this.btnexcel.Location = new System.Drawing.Point(121, 537);
            this.btnexcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(185, 57);
            this.btnexcel.TabIndex = 12;
            this.btnexcel.Text = "Xuất Excel";
            this.btnexcel.UseVisualStyleBackColor = false;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblChiPhiDichVu);
            this.panel2.Controls.Add(this.dgvChiTietDichVu);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(716, 241);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 627);
            this.panel2.TabIndex = 14;
            // 
            // lblChiPhiDichVu
            // 
            this.lblChiPhiDichVu.BackColor = System.Drawing.SystemColors.Control;
            this.lblChiPhiDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblChiPhiDichVu.ForeColor = System.Drawing.Color.Navy;
            this.lblChiPhiDichVu.Location = new System.Drawing.Point(269, 482);
            this.lblChiPhiDichVu.Name = "lblChiPhiDichVu";
            this.lblChiPhiDichVu.Size = new System.Drawing.Size(316, 36);
            this.lblChiPhiDichVu.TabIndex = 23;
            this.lblChiPhiDichVu.Text = "0 VNĐ";
            this.lblChiPhiDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvChiTietDichVu
            // 
            this.dgvChiTietDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDichVu.Location = new System.Drawing.Point(12, 114);
            this.dgvChiTietDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTietDichVu.Name = "dgvChiTietDichVu";
            this.dgvChiTietDichVu.RowHeadersWidth = 51;
            this.dgvChiTietDichVu.RowTemplate.Height = 24;
            this.dgvChiTietDichVu.Size = new System.Drawing.Size(573, 260);
            this.dgvChiTietDichVu.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(385, 409);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 29);
            this.label12.TabIndex = 21;
            this.label12.Text = "Chi phí dịch vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(144, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chi phí dịch vụ";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.numGiamGia);
            this.panel3.Controls.Add(this.lblTongCong);
            this.panel3.Controls.Add(this.lbl1);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtTienDichVu);
            this.panel3.Controls.Add(this.btnpdf);
            this.panel3.Controls.Add(this.btnexcel);
            this.panel3.Controls.Add(this.txtTienPhong);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Controls.Add(this.lblgiamgia);
            this.panel3.Controls.Add(this.lbltiendv);
            this.panel3.Controls.Add(this.lbltienphong);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.panel3.Location = new System.Drawing.Point(1340, 241);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(621, 627);
            this.panel3.TabIndex = 15;
            // 
            // numGiamGia
            // 
            this.numGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.numGiamGia.Location = new System.Drawing.Point(209, 241);
            this.numGiamGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numGiamGia.Name = "numGiamGia";
            this.numGiamGia.Size = new System.Drawing.Size(153, 34);
            this.numGiamGia.TabIndex = 25;
            this.numGiamGia.ValueChanged += new System.EventHandler(this.numGiamGia_ValueChanged);
            // 
            // lblTongCong
            // 
            this.lblTongCong.BackColor = System.Drawing.SystemColors.Control;
            this.lblTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongCong.ForeColor = System.Drawing.Color.Navy;
            this.lblTongCong.Location = new System.Drawing.Point(359, 331);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(184, 36);
            this.lblTongCong.TabIndex = 24;
            this.lblTongCong.Text = "0 VNĐ";
            this.lblTongCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.lbl1.Location = new System.Drawing.Point(364, 288);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(172, 32);
            this.lbl1.TabIndex = 17;
            this.lbl1.Text = "Tổng Cộng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(9, 482);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 29);
            this.label10.TabIndex = 16;
            this.label10.Text = "In Hóa Đơn :";
            // 
            // txtTienDichVu
            // 
            this.txtTienDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTienDichVu.Location = new System.Drawing.Point(209, 175);
            this.txtTienDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTienDichVu.Name = "txtTienDichVu";
            this.txtTienDichVu.Size = new System.Drawing.Size(384, 34);
            this.txtTienDichVu.TabIndex = 15;
            // 
            // txtTienPhong
            // 
            this.txtTienPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTienPhong.Location = new System.Drawing.Point(209, 116);
            this.txtTienPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTienPhong.Name = "txtTienPhong";
            this.txtTienPhong.Size = new System.Drawing.Size(384, 34);
            this.txtTienPhong.TabIndex = 12;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(341, 391);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(203, 57);
            this.btnThanhToan.TabIndex = 10;
            this.btnThanhToan.Text = "Thanh Toán ";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblgiamgia
            // 
            this.lblgiamgia.AutoSize = true;
            this.lblgiamgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblgiamgia.ForeColor = System.Drawing.Color.Black;
            this.lblgiamgia.Location = new System.Drawing.Point(9, 244);
            this.lblgiamgia.Name = "lblgiamgia";
            this.lblgiamgia.Size = new System.Drawing.Size(169, 29);
            this.lblgiamgia.TabIndex = 6;
            this.lblgiamgia.Text = "Giảm Giá (%)";
            // 
            // lbltiendv
            // 
            this.lbltiendv.AutoSize = true;
            this.lbltiendv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltiendv.ForeColor = System.Drawing.Color.Black;
            this.lbltiendv.Location = new System.Drawing.Point(9, 180);
            this.lbltiendv.Name = "lbltiendv";
            this.lbltiendv.Size = new System.Drawing.Size(162, 29);
            this.lbltiendv.TabIndex = 5;
            this.lbltiendv.Text = "Tiền Dịch Vụ";
            // 
            // lbltienphong
            // 
            this.lbltienphong.AutoSize = true;
            this.lbltienphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltienphong.ForeColor = System.Drawing.Color.Black;
            this.lbltienphong.Location = new System.Drawing.Point(9, 121);
            this.lbltienphong.Name = "lbltienphong";
            this.lbltienphong.Size = new System.Drawing.Size(155, 29);
            this.lbltienphong.TabIndex = 4;
            this.lbltienphong.Text = "Tiền Phòng ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(24, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(483, 42);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tổng Kết  Và Thanh Toán ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(116, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 29);
            this.label8.TabIndex = 2;
            this.label8.Text = " ";
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 977);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Tongtinkh);
            this.Controls.Add(this.lblql);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInvoice_Load);
            this.Tongtinkh.ResumeLayout(false);
            this.Tongtinkh.PerformLayout();
            this.gbthongtin.ResumeLayout(false);
            this.gbthongtin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDichVu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblql;
        private System.Windows.Forms.Panel Tongtinkh;
        private System.Windows.Forms.Label ThongTinKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label lbltong;
        private System.Windows.Forms.Label lblphong;
        private System.Windows.Forms.Label lbltenkh;
        private System.Windows.Forms.Button btnpdf;
        private System.Windows.Forms.Button btnexcel;
        private System.Windows.Forms.GroupBox gbthongtin;
        private System.Windows.Forms.Label lblsongay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvChiTietDichVu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTienDichVu;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblgiamgia;
        private System.Windows.Forms.Label lbltiendv;
        private System.Windows.Forms.Label lbltienphong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNgayTra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNgayNhan;
        private System.Windows.Forms.TextBox txtLoaiPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblChiPhiPhong;
        private System.Windows.Forms.Label lblDongiaphong;
        private System.Windows.Forms.Label lblChiPhiDichVu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.ComboBox cboSoPhong;
        private System.Windows.Forms.NumericUpDown numGiamGia;
    }
}