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
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnpdf = new System.Windows.Forms.Button();
            this.btnexcel = new System.Windows.Forms.Button();
            this.btncapnhat = new System.Windows.Forms.Button();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.txtngay = new System.Windows.Forms.TextBox();
            this.txtphong = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtma = new System.Windows.Forms.TextBox();
            this.lbltong = new System.Windows.Forms.Label();
            this.lblngay = new System.Windows.Forms.Label();
            this.lblphong = new System.Windows.Forms.Label();
            this.lbltenkh = new System.Windows.Forms.Label();
            this.lblma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblql
            // 
            this.lblql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.lblql.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblql.ForeColor = System.Drawing.Color.White;
            this.lblql.Location = new System.Drawing.Point(-1, 0);
            this.lblql.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblql.Name = "lblql";
            this.lblql.Size = new System.Drawing.Size(601, 42);
            this.lblql.TabIndex = 0;
            this.lblql.Text = "Quản Lý Hóa Đơn ";
            this.lblql.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.EnableHeadersVisualStyles = false;
            this.dgvInvoice.GridColor = System.Drawing.Color.White;
            this.dgvInvoice.Location = new System.Drawing.Point(5, 58);
            this.dgvInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersWidth = 51;
            this.dgvInvoice.RowTemplate.Height = 24;
            this.dgvInvoice.Size = new System.Drawing.Size(268, 282);
            this.dgvInvoice.TabIndex = 1;
            this.dgvInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnpdf);
            this.panel1.Controls.Add(this.btnexcel);
            this.panel1.Controls.Add(this.btncapnhat);
            this.panel1.Controls.Add(this.txttongtien);
            this.panel1.Controls.Add(this.txtngay);
            this.panel1.Controls.Add(this.txtphong);
            this.panel1.Controls.Add(this.txtten);
            this.panel1.Controls.Add(this.txtma);
            this.panel1.Controls.Add(this.lbltong);
            this.panel1.Controls.Add(this.lblngay);
            this.panel1.Controls.Add(this.lblphong);
            this.panel1.Controls.Add(this.lbltenkh);
            this.panel1.Controls.Add(this.lblma);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(301, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 282);
            this.panel1.TabIndex = 2;
            // 
            // btnpdf
            // 
            this.btnpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btnpdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpdf.ForeColor = System.Drawing.Color.White;
            this.btnpdf.Location = new System.Drawing.Point(174, 236);
            this.btnpdf.Margin = new System.Windows.Forms.Padding(2);
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(64, 26);
            this.btnpdf.TabIndex = 13;
            this.btnpdf.Text = "Xuất PDF";
            this.btnpdf.UseVisualStyleBackColor = false;
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnexcel
            // 
            this.btnexcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btnexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexcel.ForeColor = System.Drawing.Color.White;
            this.btnexcel.Location = new System.Drawing.Point(95, 236);
            this.btnexcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(74, 26);
            this.btnexcel.TabIndex = 12;
            this.btnexcel.Text = "Xuất Excel";
            this.btnexcel.UseVisualStyleBackColor = false;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // btncapnhat
            // 
            this.btncapnhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(155)))));
            this.btncapnhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncapnhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncapnhat.ForeColor = System.Drawing.Color.White;
            this.btncapnhat.Location = new System.Drawing.Point(13, 236);
            this.btncapnhat.Margin = new System.Windows.Forms.Padding(2);
            this.btncapnhat.Name = "btncapnhat";
            this.btncapnhat.Size = new System.Drawing.Size(60, 26);
            this.btncapnhat.TabIndex = 11;
            this.btncapnhat.Text = "Refresh";
            this.btncapnhat.UseVisualStyleBackColor = false;
            this.btncapnhat.Click += new System.EventHandler(this.btncapnhat_Click);
            // 
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(116, 184);
            this.txttongtien.Margin = new System.Windows.Forms.Padding(2);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.ReadOnly = true;
            this.txttongtien.Size = new System.Drawing.Size(117, 20);
            this.txttongtien.TabIndex = 10;
            // 
            // txtngay
            // 
            this.txtngay.Location = new System.Drawing.Point(116, 146);
            this.txtngay.Margin = new System.Windows.Forms.Padding(2);
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(117, 20);
            this.txtngay.TabIndex = 9;
            // 
            // txtphong
            // 
            this.txtphong.Location = new System.Drawing.Point(118, 111);
            this.txtphong.Margin = new System.Windows.Forms.Padding(2);
            this.txtphong.Name = "txtphong";
            this.txtphong.Size = new System.Drawing.Size(117, 20);
            this.txtphong.TabIndex = 8;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(118, 80);
            this.txtten.Margin = new System.Windows.Forms.Padding(2);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(120, 20);
            this.txtten.TabIndex = 7;
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(116, 47);
            this.txtma.Margin = new System.Windows.Forms.Padding(2);
            this.txtma.Multiline = true;
            this.txtma.Name = "txtma";
            this.txtma.ReadOnly = true;
            this.txtma.Size = new System.Drawing.Size(120, 19);
            this.txtma.TabIndex = 6;
            // 
            // lbltong
            // 
            this.lbltong.AutoSize = true;
            this.lbltong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltong.Location = new System.Drawing.Point(10, 184);
            this.lbltong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltong.Name = "lbltong";
            this.lbltong.Size = new System.Drawing.Size(72, 17);
            this.lbltong.TabIndex = 5;
            this.lbltong.Text = "Tổng tiền ";
            // 
            // lblngay
            // 
            this.lblngay.AutoSize = true;
            this.lblngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblngay.Location = new System.Drawing.Point(10, 146);
            this.lblngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblngay.Name = "lblngay";
            this.lblngay.Size = new System.Drawing.Size(62, 17);
            this.lblngay.TabIndex = 4;
            this.lblngay.Text = "Ngày trả";
            // 
            // lblphong
            // 
            this.lblphong.AutoSize = true;
            this.lblphong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblphong.Location = new System.Drawing.Point(10, 113);
            this.lblphong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblphong.Name = "lblphong";
            this.lblphong.Size = new System.Drawing.Size(73, 17);
            this.lblphong.TabIndex = 3;
            this.lblphong.Text = "Số phòng ";
            // 
            // lbltenkh
            // 
            this.lbltenkh.AutoSize = true;
            this.lbltenkh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbltenkh.Location = new System.Drawing.Point(10, 81);
            this.lbltenkh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltenkh.Name = "lbltenkh";
            this.lbltenkh.Size = new System.Drawing.Size(111, 17);
            this.lbltenkh.TabIndex = 2;
            this.lbltenkh.Text = "Tên khách hàng";
            // 
            // lblma
            // 
            this.lblma.AutoSize = true;
            this.lblma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblma.Location = new System.Drawing.Point(10, 47);
            this.lblma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblma.Name = "lblma";
            this.lblma.Size = new System.Drawing.Size(87, 17);
            this.lblma.TabIndex = 1;
            this.lblma.Text = "Mã hóa đơn ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(54, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi tiết hóa đơn ";
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvInvoice);
            this.Controls.Add(this.lblql);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormInvoice";
            this.Text = "FormInvoice";
            this.Load += new System.EventHandler(this.FormInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblql;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.TextBox txtngay;
        private System.Windows.Forms.TextBox txtphong;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label lbltong;
        private System.Windows.Forms.Label lblngay;
        private System.Windows.Forms.Label lblphong;
        private System.Windows.Forms.Label lbltenkh;
        private System.Windows.Forms.Label lblma;
        private System.Windows.Forms.Button btnpdf;
        private System.Windows.Forms.Button btnexcel;
        private System.Windows.Forms.Button btncapnhat;
    }
}