using System;

// =========================================================
// PHẦN 1: NƠI VIẾT CODE CHẠY CHÍNH (HOÀN THÀNH ĐOẠN NÀY)
// =========================================================

// Yêu cầu 1: Định nghĩa công thức tính phí 2% (0.02m)
Func<decimal, decimal> standardFee = (sotien) => sotien * 0.02m;

// Yêu cầu 2: Định nghĩa công thức miễn phí (trả về 0m)
Func<decimal, decimal> vipFee = (sotien) => sotien * 0m;

// Yêu cầu 3: Gọi hàm ProcessTransaction
Console.WriteLine("--- GIAO DỊCH USER A (THƯỜNG) ---");
// Gọi hàm ProcessTransaction với số tiền 1000m và công thức standardFee
ProcessTransaction(1000, standardFee);

Console.WriteLine("\n--- GIAO DỊCH USER B (VIP) ---");
// Gọi hàm ProcessTransaction với số tiền 1000m và công thức vipFee
ProcessTransaction(1000, vipFee);


// =========================================================
// PHẦN 2: HÀM XỬ LÝ LÕI (GIỮ NGUYÊN KHÔNG SỬA)
// =========================================================
static void ProcessTransaction(decimal amount, Func<decimal, decimal> feeCalculator)
{
    Console.WriteLine($"- So tien giao dich: {amount}");

    // Gọi thực thi hàm công thức được truyền vào từ bên ngoài
    decimal fee = feeCalculator(amount);

    Console.WriteLine($"- Phi giao dich he thong thu: {fee}");
    Console.WriteLine($"- Khach hang bi tru tong cong: {amount + fee}");
}