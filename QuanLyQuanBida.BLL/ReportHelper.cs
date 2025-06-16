// File: ReportHelper.cs (Chứa lớp HoaDonPrinter)

using QuanLyQuanBida.DTO; // Đảm bảo đã using DTO
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq; // Cần dùng cho .FirstOrDefault() và .Any()
using System.Windows.Forms;

public class HoaDonPrinter
{
    // Giờ đây nó nhận một danh sách thay vì một đối tượng duy nhất
    private List<HoaDonReportDTO> reportData;
    private Font printFont;
    private Font headerFont;
    private Font boldFont;
    private float leftMargin = 10;
    private float topMargin = 10;

    // Constructor nhận vào một List<HoaDonReportDTO>
    public HoaDonPrinter(List<HoaDonReportDTO> data)
    {
        this.reportData = data;
        printFont = new Font("Courier New", 10);
        headerFont = new Font("Courier New", 14, FontStyle.Bold);
        boldFont = new Font("Courier New", 10, FontStyle.Bold);
    }

    public void Print()
    {
        if (reportData == null || !reportData.Any())
        {
            MessageBox.Show("Không có dữ liệu hóa đơn để in.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        PrintDialog printDialog = new PrintDialog();
        PrintDocument printDocument = new PrintDocument();
        printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        printDialog.Document = printDocument;

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message, "Lỗi In ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public void Preview()
    {
        if (reportData == null || !reportData.Any())
        {
            MessageBox.Show("Không có dữ liệu hóa đơn để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        PrintDocument printDocument = new PrintDocument();
        printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        previewDialog.Document = printDocument;
        previewDialog.WindowState = FormWindowState.Maximized;
        previewDialog.ShowDialog();
    }

    // Phương thức vẽ chính, đọc dữ liệu từ List
    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        // Lấy thông tin chung từ dòng dữ liệu ĐẦU TIÊN (vì chúng lặp lại)
        HoaDonReportDTO headerData = reportData.FirstOrDefault();
        if (headerData == null) return; // An toàn là trên hết

        Graphics g = ev.Graphics;
        int yPos = (int)topMargin;
        float pageRightMargin = ev.MarginBounds.Right;

        // 1. Vẽ Header quán
        DrawHeader(g, ref yPos, ev.PageBounds.Width);

        // 2. Vẽ thông tin hóa đơn
        DrawInvoiceInfo(g, ref yPos, headerData);

        // 3. Vẽ bảng chi tiết dịch vụ
        DrawDetailsTable(g, ref yPos, pageRightMargin);

        // 4. Vẽ phần tổng tiền
        DrawTotals(g, ref yPos, pageRightMargin, headerData);

        // 5. Vẽ Footer
        DrawFooter(g, ref yPos, ev.PageBounds.Width);

        ev.HasMorePages = false;
    }

    // --- Các phương thức vẽ phụ trợ (đã được điền đầy đủ) ---

    private void DrawHeader(Graphics g, ref int yPos, float pageWidth)
    {
        string tenQuan = "QUÁN BIDA ở Rinascita";
        string diaChi = "140 Lê Trọng Tấn, P.Tây Thạnh, Q.Tân Phú, TP HCM";
        string sdtQuan = "SĐT: 0776848611";
        string title = "HÓA ĐƠN THANH TOÁN";

        g.DrawString(tenQuan, headerFont, Brushes.Black, CenterText(pageWidth, tenQuan, headerFont, g), yPos);
        yPos += headerFont.Height;
        g.DrawString(diaChi, printFont, Brushes.Black, CenterText(pageWidth, diaChi, printFont, g), yPos);
        yPos += printFont.Height;
        g.DrawString(sdtQuan, printFont, Brushes.Black, CenterText(pageWidth, sdtQuan, printFont, g), yPos);
        yPos += printFont.Height + 10;
        g.DrawString(title, headerFont, Brushes.Black, CenterText(pageWidth, title, headerFont, g), yPos);
        yPos += headerFont.Height + 10;
    }

    private void DrawInvoiceInfo(Graphics g, ref int yPos, HoaDonReportDTO data)
    {
        g.DrawString($"Số HĐ: {data.MaHoaDon}", printFont, Brushes.Black, leftMargin, yPos);
        string ngay = data.ThoiGianKetThuc?.ToString("dd/MM/yyyy HH:mm") ?? "";
        g.DrawString($"Ngày: {ngay}", printFont, Brushes.Black, leftMargin + 250, yPos);
        yPos += printFont.Height;

        g.DrawString($"Bàn: {data.TenBan}", printFont, Brushes.Black, leftMargin, yPos);
        g.DrawString($"NV: {data.TenNhanVien ?? "N/A"}", printFont, Brushes.Black, leftMargin + 250, yPos);
        yPos += printFont.Height;

        string tenKH = string.IsNullOrEmpty(data.TenKhachHang) ? "Khách vãng lai" : data.TenKhachHang;
        g.DrawString($"KH: {LimitString(tenKH, 30)}", printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height + 5;
    }

    private void DrawDetailsTable(Graphics g, ref int yPos, float pageRightMargin)
    {
        g.DrawLine(Pens.Black, leftMargin, yPos, pageRightMargin, yPos);
        yPos += 5;

        float tenDvCol = leftMargin;
        float slCol = leftMargin + 280;
        float donGiaCol = leftMargin + 360;
        float thanhTienCol = pageRightMargin;
        StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far };

        g.DrawString("Tên Dịch Vụ", boldFont, Brushes.Black, tenDvCol, yPos);
        g.DrawString("SL", boldFont, Brushes.Black, slCol, yPos);
        g.DrawString("Đ.Giá", boldFont, Brushes.Black, donGiaCol, yPos, rightAlign);
        g.DrawString("Thành Tiền", boldFont, Brushes.Black, thanhTienCol, yPos, rightAlign);
        yPos += boldFont.Height + 5;
        g.DrawLine(Pens.Black, leftMargin, yPos, pageRightMargin, yPos);
        yPos += 5;

        // Lặp qua danh sách reportData để vẽ từng dòng
        foreach (var item in this.reportData)
        {
            if (!string.IsNullOrEmpty(item.Item_TenDichVu))
            {
                g.DrawString(LimitString(item.Item_TenDichVu, 35), printFont, Brushes.Black, tenDvCol, yPos);
                g.DrawString(item.Item_SoLuong.ToString(), printFont, Brushes.Black, slCol, yPos);
                g.DrawString(item.Item_DonGia.ToString("N0"), printFont, Brushes.Black, donGiaCol, yPos, rightAlign);
                g.DrawString(item.Item_ThanhTien.ToString("N0"), printFont, Brushes.Black, thanhTienCol, yPos, rightAlign);
                yPos += printFont.Height;
            }
        }
    }

    private void DrawTotals(Graphics g, ref int yPos, float pageRightMargin, HoaDonReportDTO data)
    {
        g.DrawLine(Pens.Black, leftMargin, yPos, pageRightMargin, yPos);
        yPos += 5;
        float labelCol = leftMargin + 250;
        float valueCol = pageRightMargin;
        StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far };

        g.DrawString("Tổng tiền giờ:", printFont, Brushes.Black, labelCol, yPos);
        g.DrawString($"{data.TongTienGio:N0}", printFont, Brushes.Black, valueCol, yPos, rightAlign);
        yPos += printFont.Height;

        g.DrawString("Tổng tiền dịch vụ:", printFont, Brushes.Black, labelCol, yPos);
        g.DrawString($"{data.TongTienDichVu:N0}", printFont, Brushes.Black, valueCol, yPos, rightAlign);
        yPos += printFont.Height;

        if (data.GiamGia > 0)
        {
            g.DrawString("Giảm giá:", printFont, Brushes.Black, labelCol, yPos);
            g.DrawString($"{data.GiamGia:N0}", printFont, Brushes.Black, valueCol, yPos, rightAlign);
            yPos += printFont.Height;
        }

        yPos += 5;
        g.DrawString("TỔNG CỘNG:", boldFont, Brushes.Black, labelCol, yPos);
        g.DrawString($"{data.TongThanhToan:N0} đ", boldFont, Brushes.Black, valueCol, yPos, rightAlign);
        yPos += boldFont.Height + 20;
    }

    private void DrawFooter(Graphics g, ref int yPos, float pageWidth)
    {
        string camOn = "Cảm ơn quý khách!";
        string henGapLai = "Hẹn gặp lại!";
        g.DrawString(camOn, printFont, Brushes.Black, CenterText(pageWidth, camOn, printFont, g), yPos);
        yPos += printFont.Height;
        g.DrawString(henGapLai, printFont, Brushes.Black, CenterText(pageWidth, henGapLai, printFont, g), yPos);
    }

    // --- Các hàm tiện ích ---

    private float CenterText(float pageWidth, string text, Font font, Graphics g)
    {
        SizeF stringSize = g.MeasureString(text, font);
        return (pageWidth - stringSize.Width) / 2;
    }

    private string LimitString(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text)) return "";
        return text.Length <= maxLength ? text : text.Substring(0, maxLength - 3) + "...";
    }
}