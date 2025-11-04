using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

// Thêm alias để tránh conflict với System.Drawing.Font
using iTextFont = iTextSharp.text.Font;


        // 🔹 Thiết lập style cho các DataGridView
        private void SetupDataGridViews()
        {
            dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT hd.MaHoaDon, kh.HoTen AS TenKhachHang, p.SoPhong AS TenPhong,
                         dp.NgayNhan, dp.NgayTra, hd.ThanhTien
                         FROM HoaDon hd
                         JOIN DatPhong dp ON hd.MaDatPhong = dp.MaDatPhong
                         JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                         JOIN Phong p ON dp.MaPhong = p.MaPhong
                         ORDER BY hd.NgayLap DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            dgvInvoice.DataSource = dt;
        }
        private void LoadSampleData()
        private void LoadThongTinKhachHang()
        {
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoice.RowHeadersVisible = false;
            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoice.BackgroundColor = Color.White;

            dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 35, 66);
            dgvInvoice.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInvoice.EnableHeadersVisualStyles = false;
        }

        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvInvoice.Rows.Count)
                    return;

                DataGridViewRow row = dgvInvoice.Rows[e.RowIndex];

                txtma.Text = row.Cells[0].Value?.ToString() ?? "";       // MaHoaDon
                txtten.Text = row.Cells[1].Value?.ToString() ?? "";      // TenKhachHang
                txtphong.Text = row.Cells[2].Value?.ToString() ?? "";    // TenPhong
                txtngay.Text = row.Cells[4].Value?.ToString() ?? "";     // NgayTra

                if (decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal total)) // ThanhTien
                {
                    txttongtien.Text = string.Format("{0:N0} VNĐ", total);
                }
                else
                {
                    txttongtien.Text = "0 VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn hóa đơn: " + ex.Message);
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            txtma.Clear();
            txtten.Clear();
            txtphong.Clear();
            txtngay.Clear();
            txttongtien.Clear();

            LoadInvoice();
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "HoaDon.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets.Add("HoaDon");

                            // Thêm tiêu đề cột
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                ws.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                                ws.Cells[1, i + 1].Style.Font.Bold = true;
                            }

                            // Thêm dữ liệu
                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                for (int c = 0; c < dt.Columns.Count; c++)
                                {
                                    ws.Cells[r + 2, c + 1].Value = dt.Rows[r][c];

                                    // Định dạng cột ThanhTien
                                    if (dt.Columns[c].ColumnName == "ThanhTien" && dt.Rows[r][c] != DBNull.Value)
                                    {
                                        ws.Cells[r + 2, c + 1].Style.Numberformat.Format = "#,##0 \"VNĐ\"";
                                    }
                                }
                            }

                            // Tự động căn chỉnh cột
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();

                            package.SaveAs(new FileInfo(sfd.FileName));
                            MessageBox.Show("Xuất Excel thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                    }
                }
            }
        }
        private void btnpdf_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất PDF.");
                return;
            }

            using (SaveFileDialog save = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = "HoaDon.pdf" })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                        {
                            var doc = new iTextSharp.text.Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                            PdfWriter.GetInstance(doc, stream);
                            doc.Open();

                            // Tiêu đề PDF
                            var title = new Paragraph("DANH SÁCH HÓA ĐƠN",
                                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, iTextBaseColor.BLACK))
                            { Alignment = Element.ALIGN_CENTER };
                            doc.Add(title);
                            doc.Add(new Paragraph("\n"));

                            PdfPTable table = new PdfPTable(dgvInvoice.Columns.Count);
                            table.WidthPercentage = 100;

                            // Header
                            foreach (DataGridViewColumn col in dgvInvoice.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText,
                                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, iTextBaseColor.WHITE)));
                                cell.BackgroundColor = new iTextBaseColor(10, 35, 66);
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.Padding = 5;
                                table.AddCell(cell);
                            }

                            // Rows dữ liệu
                            foreach (DataGridViewRow row in dgvInvoice.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(cell.Value?.ToString() ?? "");
                                }
                            }

                            doc.Add(table);
                            doc.Close();
                        }

                        MessageBox.Show("Xuất PDF thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi PDF: " + ex.Message);
                    }
                }
            }
        }
    }
}