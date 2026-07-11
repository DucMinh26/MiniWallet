using System;
using System.Threading;
using System.Threading.Tasks;

// =========================================================
// PHẦN 1: NƠI VIẾT CODE CHẠY CHÍNH (SỬA LẠI THÊM AWAIT CHO ĐÚNG)
// =========================================================
Console.WriteLine("1. Bat dau xu ly giao dich...");

// Gọi hàm kiểm tra số dư (Đang bị block hệ thống, hãy sửa lại)
decimal balance = await CheckBalance(userId: "USER_001");
Console.WriteLine($"2. So du hien tai: {balance}");

// Gọi hàm trừ tiền (Đang bị block hệ thống, hãy sửa lại)
ProcessPayment(amount: 500);

Console.WriteLine("4. Giao dich hoan tat!");


// =========================================================
// PHẦN 2: CÁC HÀM XỬ LÝ (SỬA THÀNH BẤT ĐỒNG BỘ ASYNC/AWAIT)
// =========================================================

// YÊU CẦU 1: Đổi hàm này thành async trả về Task<decimal>
async static Task<decimal> CheckBalance(string userId)
{
    Console.WriteLine("-> Dang ket noi toi Database de kiem tra so du...");
    await Task.Delay(2000); // Mất 2 giây (HÃY SỬA THÀNH Task.Delay)
    return 1500; // Trả về số dư giả lập
}

// YÊU CẦU 2: Đổi hàm này thành async trả về Task (tương đương void)
async static void ProcessPayment(decimal amount)
{
    Console.WriteLine($"-> Dang goi sang Ngan hang de tru {amount} VND...");
    await Task.Delay(3000); // Mất 3 giây (HÃY SỬA THÀNH Task.Delay)
    Console.WriteLine("3. Tru tien thanh cong tu Ngan hang.");
}