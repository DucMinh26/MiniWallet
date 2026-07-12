using System;

// =========================================================
// PHẦN 1: NƠI VIẾT CODE CHẠY CHÍNH
// =========================================================

// Yêu cầu 2: Khởi tạo response bọc một số decimal (500000m)
ApiResponse<decimal> balanceResponse = new ApiResponse<decimal>
{
    IsSuccess = true,
    Data = 500000m,
    ErrorMessage = null
};

// Yêu cầu 3: Khởi tạo response bọc một chuỗi string, báo lỗi "So du khong du"
ApiResponse<string> errorResponse = new ApiResponse<string>
{
    IsSuccess = false,
    Data = null,
    ErrorMessage = "So du khong du"
};


Console.WriteLine($"API 1 - Success: {balanceResponse.IsSuccess} | Data: {balanceResponse.Data}");
Console.WriteLine($"API 2 - Success: {errorResponse.IsSuccess} | Error: {errorResponse.ErrorMessage}");


// =========================================================
// PHẦN 2: NƠI ĐỊNH NGHĨA CLASS GENERICS
// =========================================================

// Yêu cầu 1: Hoàn thiện class ApiResponse<T>
public class ApiResponse<T>
{
    // Viết 3 properties: IsSuccess, Data, ErrorMessage vào đây
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
}