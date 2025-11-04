namespace abchotel
{
    partial class FormReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblbc = new System.Windows.Forms.Label();
            this.cboloaibc = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblvaluessohoadon = new System.Windows.Forms.Label();
            this.lblvaluesdthu = new System.Windows.Forms.Label();
            this.lblsohoadon = new System.Windows.Forms.Label();
            this.lbltongdoanhthu = new System.Windows.Forms.Label();
            this.chdthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblto = new System.Windows.Forms.Label();
            this.lblfrom = new System.Windows.Forms.Label();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.lblloai = new System.Windows.Forms.Label();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.btntk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvdt = new System.Windows.Forms.DataGridView();
            this.btnxuat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chdthu)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbc
            // 
            this.lblbc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.lblbc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblbc.ForeColor = System.Drawing.Color.White;
            this.lblbc.Location = new System.Drawing.Point(0, 0);
            this.lblbc.Name = "lblbc";
            this.lblbc.Size = new System.Drawing.Size(1072, 42);
            this.lblbc.TabIndex = 0;
            this.lblbc.Text = "BÁO CÁO DOANH THU \r\n";
            this.lblbc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboloaibc
            // 
            this.cboloaibc.FormattingEnabled = true;
            this.cboloaibc.Location = new System.Drawing.Point(137, 10);
            this.cboloaibc.Name = "cboloaibc";
            this.cboloaibc.Size = new System.Drawing.Size(222, 24);
            this.cboloaibc.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnxuat);
            this.panel1.Controls.Add(this.dgvdt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chdthu);
            this.panel1.Controls.Add(this.lblto);
            this.panel1.Controls.Add(this.lblfrom);
            this.panel1.Controls.Add(this.dtto);
            this.panel1.Controls.Add(this.lblloai);
            this.panel1.Controls.Add(this.dtfrom);
            this.panel1.Controls.Add(this.btntk);
            this.panel1.Controls.Add(this.cboloaibc);
            this.panel1.Location = new System.Drawing.Point(23, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 450);
            this.panel1.TabIndex = 2;
            // 
            // lblvaluessohoadon
            // 
            this.lblvaluessohoadon.AutoSize = true;
            this.lblvaluessohoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblvaluessohoadon.Location = new System.Drawing.Point(139, 39);
            this.lblvaluessohoadon.Name = "lblvaluessohoadon";
            this.lblvaluessohoadon.Size = new System.Drawing.Size(64, 25);
            this.lblvaluessohoadon.TabIndex = 12;
            this.lblvaluessohoadon.Text = "label2";
            // 
            // lblvaluesdthu
            // 
            this.lblvaluesdthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblvaluesdthu.Location = new System.Drawing.Point(159, 1);
            this.lblvaluesdthu.Name = "lblvaluesdthu";
            this.lblvaluesdthu.Size = new System.Drawing.Size(77, 25);
            this.lblvaluesdthu.TabIndex = 11;
            this.lblvaluesdthu.Text = "label1";
            this.lblvaluesdthu.Click += new System.EventHandler(this.lblvaluesdthu_Click);
            // 
            // lblsohoadon
            // 
            this.lblsohoadon.AutoSize = true;
            this.lblsohoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsohoadon.Location = new System.Drawing.Point(14, 39);
            this.lblsohoadon.Name = "lblsohoadon";
            this.lblsohoadon.Size = new System.Drawing.Size(119, 25);
            this.lblsohoadon.TabIndex = 10;
            this.lblsohoadon.Text = "Số hóa đơn:";
            // 
            // lbltongdoanhthu
            // 
            this.lbltongdoanhthu.AutoSize = true;
            this.lbltongdoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltongdoanhthu.Location = new System.Drawing.Point(4, 1);
            this.lbltongdoanhthu.Name = "lbltongdoanhthu";
            this.lbltongdoanhthu.Size = new System.Drawing.Size(161, 25);
            this.lbltongdoanhthu.TabIndex = 9;
            this.lbltongdoanhthu.Text = "Tổng doanh thu: ";
            // 
            // chdthu
            // 
            chartArea9.Name = "ChartArea1";
            this.chdthu.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chdthu.Legends.Add(legend9);
            this.chdthu.Location = new System.Drawing.Point(444, 82);
            this.chdthu.Name = "chdthu";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chdthu.Series.Add(series9);
            this.chdthu.Size = new System.Drawing.Size(589, 305);
            this.chdthu.TabIndex = 6;
            this.chdthu.Text = "Doanh thu";
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblto.Location = new System.Drawing.Point(263, 54);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(44, 20);
            this.lblto.TabIndex = 8;
            this.lblto.Text = "Đến:";
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblfrom.Location = new System.Drawing.Point(3, 54);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(38, 20);
            this.lblfrom.TabIndex = 7;
            this.lblfrom.Text = "Từ: ";
            // 
            // dtto
            // 
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(332, 54);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(200, 22);
            this.dtto.TabIndex = 2;
            // 
            // lblloai
            // 
            this.lblloai.AutoSize = true;
            this.lblloai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblloai.Location = new System.Drawing.Point(3, 10);
            this.lblloai.Name = "lblloai";
            this.lblloai.Size = new System.Drawing.Size(110, 20);
            this.lblloai.TabIndex = 6;
            this.lblloai.Text = "Loại báo cáo ";
            // 
            // dtfrom
            // 
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(56, 54);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(187, 22);
            this.dtfrom.TabIndex = 3;
            // 
            // btntk
            // 
            this.btntk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btntk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntk.ForeColor = System.Drawing.Color.White;
            this.btntk.Location = new System.Drawing.Point(386, 8);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(124, 37);
            this.btntk.TabIndex = 4;
            this.btntk.Text = "Xem Báo Cáo";
            this.btntk.UseVisualStyleBackColor = false;
            this.btntk.Click += new System.EventHandler(this.btntk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblvaluessohoadon);
            this.panel2.Controls.Add(this.lblvaluesdthu);
            this.panel2.Controls.Add(this.lblsohoadon);
            this.panel2.Controls.Add(this.lbltongdoanhthu);
            this.panel2.Location = new System.Drawing.Point(580, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 66);
            this.panel2.TabIndex = 13;
            // 
            // dgvdt
            // 
            this.dgvdt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.dgvdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdt.Location = new System.Drawing.Point(7, 82);
            this.dgvdt.Name = "dgvdt";
            this.dgvdt.RowHeadersWidth = 51;
            this.dgvdt.RowTemplate.Height = 24;
            this.dgvdt.Size = new System.Drawing.Size(431, 305);
            this.dgvdt.TabIndex = 14;
            // 
            // btnxuat
            // 
            this.btnxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btnxuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxuat.ForeColor = System.Drawing.Color.White;
            this.btnxuat.Location = new System.Drawing.Point(72, 393);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(311, 39);
            this.btnxuat.TabIndex = 15;
            this.btnxuat.Text = "Xuất bảng dữ liệu chi tiết (excel)";
            this.btnxuat.UseVisualStyleBackColor = false;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblbc);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formReport_FormClosing);
            this.Load += new System.EventHandler(this.formReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chdthu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblbc;
        private System.Windows.Forms.ComboBox cboloaibc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chdthu;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.Label lblloai;
        private System.Windows.Forms.Label lblsohoadon;
        private System.Windows.Forms.Label lbltongdoanhthu;
        private System.Windows.Forms.Label lblvaluessohoadon;
        private System.Windows.Forms.Label lblvaluesdthu;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.DataGridView dgvdt;
        private System.Windows.Forms.Panel panel2;
    }
}