using QuanLyQuanBida.DTO;
using System;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;       
using System.Windows.Forms; 

public class HoaDonPrinter
{
    private HoaDonDTO hoaDonToPrint;
    private Font printFont;
    private Font headerFont;
    private Font boldFont;
    private int linesPerPage = 0;
    private int yPos = 0;
    private int count = 0;
    private float leftMargin = 10;
    private float topMargin = 10;
    private string line = "                                                    ---------------------------------------------------------------"; 

    public HoaDonPrinter(HoaDonDTO hoaDon)
    {
        this.hoaDonToPrint = hoaDon;
        printFont = new Font("Arial", 10);
        headerFont = new Font("Arial", 14, FontStyle.Bold);
        boldFont = new Font("Arial", 10, FontStyle.Bold);
    }

    public void Print()
    {
        if (hoaDonToPrint == null)
        {
            MessageBox.Show("Không có thông tin hóa đơn để in.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        PrintDialog printDialog = new PrintDialog();
        PrintDocument printDocument = new PrintDocument();

        // Gán sự kiện PrintPage
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
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi In ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public void Preview()
    {
        if (hoaDonToPrint == null)
        {
            MessageBox.Show("Không có thông tin hóa đơn để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        PrintDocument printDocument = new PrintDocument();
        printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);

        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        previewDialog.Document = printDocument;
        previewDialog.WindowState = FormWindowState.Maximized;
        previewDialog.ShowDialog();
    }


    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        yPos = (int)topMargin;
        count = 0;

        Graphics g = ev.Graphics;
        float pageHeight = ev.MarginBounds.Height; 

        string tenQuan = "QUÁN BIDA ở Rinascita";
        string diaChi = "140 Đường Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú, TP HCM";
        string sdtQuan = "SĐT: 0776848611";

        g.DrawString(tenQuan, headerFont, Brushes.Black, leftMargin, yPos);
        yPos += headerFont.Height + 5;
        g.DrawString(diaChi, printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height;
        g.DrawString(sdtQuan, printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height + 10;

        // 2. Tiêu đề Hóa Đơn
        g.DrawString("HÓA ĐƠN THANH TOÁN", headerFont, Brushes.Black, CenterText(ev.PageBounds.Width, "HÓA ĐƠN THANH TOÁN", headerFont, g), yPos);
        yPos += headerFont.Height + 10;

        // 3. Thông tin hóa đơn
        g.DrawString($"Số HĐ: {hoaDonToPrint.MaHoaDon}", printFont, Brushes.Black, leftMargin, yPos);
        g.DrawString($"Ngày: {hoaDonToPrint.ThoiGianKetThuc?.ToString("dd/MM/yyyy HH:mm") ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm")}", printFont, Brushes.Black, leftMargin + 250, yPos); // Căn phải
        yPos += printFont.Height;
        g.DrawString($"Bàn: {hoaDonToPrint.TenBan}", printFont, Brushes.Black, leftMargin, yPos);
        // g.DrawString($"Nhân viên: {GetTenNhanVien(hoaDonToPrint.MaNhanVienTao)}", printFont, Brushes.Black, leftMargin + 250, yPos);
        yPos += printFont.Height;
        // g.DrawString($"Khách hàng: {GetTenKhachHang(hoaDonToPrint.MaKhachHang)}", printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height + 5;

        g.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height;

        // 4. Chi tiết dịch vụ (bảng)
        // Header bảng
        g.DrawString("Tên DV", boldFont, Brushes.Black, leftMargin, yPos);
        g.DrawString("SL", boldFont, Brushes.Black, leftMargin + 200, yPos);
        g.DrawString("Đ.Giá", boldFont, Brushes.Black, leftMargin + 250, yPos);
        g.DrawString("T.Tiền", boldFont, Brushes.Black, leftMargin + 350, yPos);
        yPos += boldFont.Height;
        g.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height;

        // Tiền giờ (nếu có)
        if (hoaDonToPrint.TienGio.HasValue && hoaDonToPrint.TienGio > 0)
        {
            g.DrawString("Tiền giờ", printFont, Brushes.Black, leftMargin, yPos);
            // Bạn có thể hiển thị số giờ/phút chơi ở đây nếu có thông tin
            g.DrawString("", printFont, Brushes.Black, leftMargin + 200, yPos); // SL
            g.DrawString("", printFont, Brushes.Black, leftMargin + 250, yPos); // Đơn giá giờ (nếu có)
            g.DrawString($"{hoaDonToPrint.TienGio.Value:N0}", printFont, Brushes.Black, leftMargin + 350, yPos);
            yPos += printFont.Height;
        }

        // Các dịch vụ khác
        if (hoaDonToPrint.ChiTietDichVu != null)
        {
            foreach (var item in hoaDonToPrint.ChiTietDichVu)
            {
                // Giả sử ChiTietHoaDonDTO có TenDichVu, hoặc bạn cần lấy tên DV từ MaDichVu
                g.DrawString(LimitString(item.TenDichVu, 25), printFont, Brushes.Black, leftMargin, yPos); // Giới hạn độ dài tên DV
                g.DrawString(item.SoLuong.ToString(), printFont, Brushes.Black, leftMargin + 200, yPos);
                g.DrawString(item.DonGia.ToString("N0"), printFont, Brushes.Black, leftMargin + 250, yPos);
                g.DrawString((item.SoLuong * item.DonGia).ToString("N0"), printFont, Brushes.Black, leftMargin + 350, yPos);
                yPos += printFont.Height;

                // Kiểm tra nếu cần sang trang mới (ví dụ đơn giản)
                if (yPos + printFont.Height > pageHeight)
                {
                    ev.HasMorePages = true;
                    return; // Dừng vẽ trang hiện tại
                }
            }
        }
        g.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
        yPos += printFont.Height;

        // 5. Tổng cộng
        if (hoaDonToPrint.TienDichVu.HasValue) // Tổng tiền dịch vụ riêng (không bao gồm tiền giờ)
        {
            g.DrawString("Tổng tiền dịch vụ:", printFont, Brushes.Black, leftMargin + 150, yPos);
            g.DrawString($"{hoaDonToPrint.TienDichVu.Value:N0}", printFont, Brushes.Black, leftMargin + 350, yPos);
            yPos += printFont.Height;
        }
        if (hoaDonToPrint.GiamGia.HasValue && hoaDonToPrint.GiamGia > 0)
        {
            g.DrawString("Giảm giá:", printFont, Brushes.Black, leftMargin + 150, yPos);
            g.DrawString($"{hoaDonToPrint.GiamGia.Value:N0}", printFont, Brushes.Black, leftMargin + 350, yPos);
            yPos += printFont.Height;
        }

        g.DrawString("TỔNG CỘNG:", boldFont, Brushes.Black, leftMargin + 150, yPos);
        g.DrawString($"{hoaDonToPrint.TongTien?.ToString("N0") ?? "0"} đ", boldFont, Brushes.Black, leftMargin + 350, yPos);
        yPos += boldFont.Height + 20;

        // 6. Footer
        g.DrawString("Cảm ơn quý khách!", printFont, Brushes.Black, CenterText(ev.PageBounds.Width, "Cảm ơn quý khách!", printFont, g), yPos);
        yPos += printFont.Height;
        g.DrawString("Hẹn gặp lại!", printFont, Brushes.Black, CenterText(ev.PageBounds.Width, "Hẹn gặp lại!", printFont, g), yPos);

        // Báo cho printer biết không còn trang nào để in
        ev.HasMorePages = false;
    }

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