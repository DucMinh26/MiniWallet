using System;

// =========================================================
// PHẦN 1: NƠI VIẾT CODE CHẠY CHÍNH
// =========================================================
decimal accountBalance = 12500000m; // 12.5 triệu

// YÊU CẦU 2: Gọi Extension Method bạn vừa viết thông qua biến accountBalance
string displayBalance = accountBalance.ToVndCurrency();

Console.WriteLine($"So du cua ban la: {displayBalance}");
// Kết quả in ra màn hình phải đúng y hệt như sau: So du cua ban la: 12,500,000 VND


// =========================================================
// PHẦN 2: ĐỊNH NGHĨA EXTENSION METHOD
// =========================================================

// YÊU CẦU 1: Hoàn thiện lớp tĩnh và phương thức tĩnh này
public static class DecimalExtensions
{
    // Viết hàm ToVndCurrency() tại đây
    public static string ToVndCurrency(this decimal soTien)
    {
        return soTien.ToString("#,##0" + " VND");
    }
}