using System;
using System.Text.Json;

// =========================================================
// PHẦN 1: NƠI VIẾT CODE CHẠY CHÍNH
// =========================================================

// Đây là chuỗi JSON do Mobile App gửi lên
string incomingJson = "{\"TransactionId\":\"TXN-999\",\"Amount\":500000,\"Type\":\"Deposit\",\"Status\":\"Pending\"}";
Console.WriteLine("1. JSON NHẬN ĐƯỢC TỪ MOBILE:");
Console.WriteLine(incomingJson);

// YÊU CẦU 2: Deserialize chuỗi incomingJson thành class C#
TransactionRequest transaction = JsonSerializer.Deserialize<TransactionRequest>(incomingJson);

// YÊU CẦU 3: Cập nhật Status thành "Success"
transaction.Status = "Success";

// YÊU CẦU 4: Serialize đối tượng transaction thành chuỗi JSON mới (có format đẹp)
// Gợi ý: Tìm hiểu lớp JsonSerializerOptions
var options = new JsonSerializerOptions
{
    WriteIndented = true
};
string responseJson = JsonSerializer.Serialize(transaction, options);

Console.WriteLine("\n2. JSON TRẢ VỀ CHO MOBILE:");
Console.WriteLine(responseJson);


// =========================================================
// PHẦN 2: NƠI ĐỊNH NGHĨA CLASS
// =========================================================

// YÊU CẦU 1: Hoàn thiện cấu trúc class này khớp với JSON
public class TransactionRequest
{
    // Viết 4 thuộc tính (Properties) vào đây
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
}