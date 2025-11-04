using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace abchotel
{
    public partial class FormInvoice : Form
    {
        string connectionString = @"Data Source=ANHENHS\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        // 💰 GLOBAL VARIABLES
        decimal tongPhong = 0, tongDV = 0, tongTamTinh = 0, tongCong = 0;

        // 🔑 Dùng INT cho ID vì MaHoaDon trong DB là INT
        private int currentMaHoaDon = 1;
        private readonly object hienthucTT;

        public FormInvoice()
        {
            InitializeComponent();
        }
    }
}