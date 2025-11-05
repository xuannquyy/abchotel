namespace abchotel
{
    partial class Formlgin
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
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLblQuenmk = new System.Windows.Forms.LinkLabel();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxhienmk = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDangnhap.ForeColor = System.Drawing.Color.White;
            this.btnDangnhap.Location = new System.Drawing.Point(119, 230);
            this.btnDangnhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(164, 35);
            this.btnDangnhap.TabIndex = 0;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = false;
            this.btnDangnhap.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(160, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(31, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên tài khoản";
            // 
            // linkLblQuenmk
            // 
            this.linkLblQuenmk.AutoSize = true;
            this.linkLblQuenmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblQuenmk.Location = new System.Drawing.Point(149, 283);
            this.linkLblQuenmk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLblQuenmk.Name = "linkLblQuenmk";
            this.linkLblQuenmk.Size = new System.Drawing.Size(103, 16);
            this.linkLblQuenmk.TabIndex = 5;
            this.linkLblQuenmk.TabStop = true;
            this.linkLblQuenmk.Text = "Quên mật khẩu?";
            this.linkLblQuenmk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(129, 104);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTen.Multiline = true;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(229, 28);
            this.txtTen.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(31, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật Khẩu";
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(129, 165);
            this.txtMatkhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatkhau.Multiline = true;
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '*';
            this.txtMatkhau.Size = new System.Drawing.Size(229, 28);
            this.txtMatkhau.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-1, -3);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(728, 49);
            this.label4.TabIndex = 9;
            this.label4.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBoxhienmk);
            this.panel1.Controls.Add(this.linkLblQuenmk);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDangnhap);
            this.panel1.Controls.Add(this.txtMatkhau);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Location = new System.Drawing.Point(159, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 386);
            this.panel1.TabIndex = 10;
            // 
            // checkBoxhienmk
            // 
            this.checkBoxhienmk.AutoSize = true;
            this.checkBoxhienmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.checkBoxhienmk.Location = new System.Drawing.Point(276, 203);
            this.checkBoxhienmk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxhienmk.Name = "checkBoxhienmk";
            this.checkBoxhienmk.Size = new System.Drawing.Size(93, 17);
            this.checkBoxhienmk.TabIndex = 4;
            this.checkBoxhienmk.Text = "Hiện mật khẩu";
            this.checkBoxhienmk.UseVisualStyleBackColor = true;
            this.checkBoxhienmk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Formlgin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(724, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Formlgin";
            this.Text = "Formlogin";
            this.Load += new System.EventHandler(this.Formlgin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLblQuenmk;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxhienmk;
    }
}