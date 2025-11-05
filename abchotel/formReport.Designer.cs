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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblbc = new System.Windows.Forms.Label();
            this.cboloaibc = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnxuat = new System.Windows.Forms.Button();
            this.dgvdt = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chdthu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbc
            // 
            this.lblbc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.lblbc.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblbc.ForeColor = System.Drawing.Color.White;
            this.lblbc.Location = new System.Drawing.Point(-204, 0);
            this.lblbc.Name = "lblbc";
            this.lblbc.Size = new System.Drawing.Size(2251, 63);
            this.lblbc.TabIndex = 0;
            this.lblbc.Text = "BÁO CÁO DOANH THU \r\n";
            this.lblbc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboloaibc
            // 
            this.cboloaibc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboloaibc.FormattingEnabled = true;
            this.cboloaibc.Location = new System.Drawing.Point(432, 64);
            this.cboloaibc.Name = "cboloaibc";
            this.cboloaibc.Size = new System.Drawing.Size(313, 37);
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
            this.panel1.Location = new System.Drawing.Point(12, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1900, 972);
            this.panel1.TabIndex = 2;
            // 
            // btnxuat
            // 
            this.btnxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btnxuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnxuat.ForeColor = System.Drawing.Color.White;
            this.btnxuat.Location = new System.Drawing.Point(766, 870);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(390, 68);
            this.btnxuat.TabIndex = 15;
            this.btnxuat.Text = "Xuất bảng dữ liệu chi tiết (excel)";
            this.btnxuat.UseVisualStyleBackColor = false;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // dgvdt
            // 
            this.dgvdt.BackgroundColor = System.Drawing.Color.White;
            this.dgvdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdt.Location = new System.Drawing.Point(108, 203);
            this.dgvdt.Name = "dgvdt";
            this.dgvdt.RowHeadersWidth = 51;
            this.dgvdt.RowTemplate.Height = 24;
            this.dgvdt.Size = new System.Drawing.Size(860, 624);
            this.dgvdt.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblvaluessohoadon);
            this.panel2.Controls.Add(this.lblvaluesdthu);
            this.panel2.Controls.Add(this.lblsohoadon);
            this.panel2.Controls.Add(this.lbltongdoanhthu);
            this.panel2.Location = new System.Drawing.Point(1114, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 84);
            this.panel2.TabIndex = 13;
            // 
            // lblvaluessohoadon
            // 
            this.lblvaluessohoadon.AutoSize = true;
            this.lblvaluessohoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblvaluessohoadon.Location = new System.Drawing.Point(238, 41);
            this.lblvaluessohoadon.Name = "lblvaluessohoadon";
            this.lblvaluessohoadon.Size = new System.Drawing.Size(92, 32);
            this.lblvaluessohoadon.TabIndex = 12;
            this.lblvaluessohoadon.Text = "label2";
            // 
            // lblvaluesdthu
            // 
            this.lblvaluesdthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblvaluesdthu.Location = new System.Drawing.Point(238, 3);
            this.lblvaluesdthu.Name = "lblvaluesdthu";
            this.lblvaluesdthu.Size = new System.Drawing.Size(281, 38);
            this.lblvaluesdthu.TabIndex = 11;
            this.lblvaluesdthu.Text = "label1";
            // 
            // lblsohoadon
            // 
            this.lblsohoadon.AutoSize = true;
            this.lblsohoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsohoadon.Location = new System.Drawing.Point(14, 39);
            this.lblsohoadon.Name = "lblsohoadon";
            this.lblsohoadon.Size = new System.Drawing.Size(167, 32);
            this.lblsohoadon.TabIndex = 10;
            this.lblsohoadon.Text = "Số hóa đơn:";
            // 
            // lbltongdoanhthu
            // 
            this.lbltongdoanhthu.AutoSize = true;
            this.lbltongdoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltongdoanhthu.Location = new System.Drawing.Point(4, 7);
            this.lbltongdoanhthu.Name = "lbltongdoanhthu";
            this.lbltongdoanhthu.Size = new System.Drawing.Size(228, 32);
            this.lbltongdoanhthu.TabIndex = 9;
            this.lbltongdoanhthu.Text = "Tổng doanh thu: ";
            // 
            // chdthu
            // 
            chartArea2.Name = "ChartArea1";
            this.chdthu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chdthu.Legends.Add(legend2);
            this.chdthu.Location = new System.Drawing.Point(974, 203);
            this.chdthu.Name = "chdthu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chdthu.Series.Add(series2);
            this.chdthu.Size = new System.Drawing.Size(900, 624);
            this.chdthu.TabIndex = 6;
            this.chdthu.Text = "Doanh thu";
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblto.Location = new System.Drawing.Point(480, 136);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(74, 32);
            this.lblto.TabIndex = 8;
            this.lblto.Text = "Đến:";
            this.lblto.Click += new System.EventHandler(this.lblto_Click);
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblfrom.Location = new System.Drawing.Point(184, 144);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(62, 32);
            this.lblfrom.TabIndex = 7;
            this.lblfrom.Text = "Từ: ";
            this.lblfrom.Click += new System.EventHandler(this.lblfrom_Click);
            // 
            // dtto
            // 
            this.dtto.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(576, 144);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(200, 22);
            this.dtto.TabIndex = 2;
            this.dtto.ValueChanged += new System.EventHandler(this.dtto_ValueChanged);
            // 
            // lblloai
            // 
            this.lblloai.AutoSize = true;
            this.lblloai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblloai.Location = new System.Drawing.Point(184, 66);
            this.lblloai.Name = "lblloai";
            this.lblloai.Size = new System.Drawing.Size(197, 32);
            this.lblloai.TabIndex = 6;
            this.lblloai.Text = "Loại báo cáo ";
            // 
            // dtfrom
            // 
            this.dtfrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtfrom.Location = new System.Drawing.Point(272, 146);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(186, 22);
            this.dtfrom.TabIndex = 3;
            // 
            // btntk
            // 
            this.btntk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btntk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntk.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btntk.ForeColor = System.Drawing.Color.White;
            this.btntk.Location = new System.Drawing.Point(812, 68);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(224, 60);
            this.btntk.TabIndex = 4;
            this.btntk.Text = "Xem Báo Cáo";
            this.btntk.UseVisualStyleBackColor = false;
            this.btntk.Click += new System.EventHandler(this.btntk_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblbc);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chdthu)).EndInit();
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