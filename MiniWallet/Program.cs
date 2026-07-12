using System;
using System.Diagnostics;
using System.Threading.Tasks;

Console.WriteLine("Bat dau tai trang Dashboard...");
Stopwatch sw = Stopwatch.StartNew(); // Bật đồng hồ bấm giờ

// =========================================================
// PHẦN 1: TỐI ƯU HÓA ĐOẠN CODE NÀY (DÙNG Task.WhenAll)
// =========================================================
// Xóa 2 dòng dưới đây và viết lại bằng Task.WhenAll để chạy song song.

Task<decimal> balance = GetBalanceAsync();
Task<int> unreadMessages = GetUnreadMessagesAsync();
await Task.WhenAll(balance, unreadMessages);

// =========================================================

sw.Stop(); // Tắt đồng hồ
Console.WriteLine($"Tai xong! So du: {balance.Result} | Tin nhan: {unreadMessages.Result}");
Console.WriteLine($"Tong thoi gian: {sw.ElapsedMilliseconds} ms"); // Kết quả phải xấp xỉ 3000 ms

// =========================================================
// PHẦN 2: CÁC HÀM XỬ LÝ (GIỮ NGUYÊN KHÔNG SỬA)
// =========================================================
static async Task<decimal> GetBalanceAsync()
{
    await Task.Delay(2000);
    return 50000;
}

static async Task<int> GetUnreadMessagesAsync()
{
    await Task.Delay(3000);
    return 5;
}