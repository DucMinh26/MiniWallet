using System;

// =========================================================
// PHẦN 1: NƠI VIẾT CODE CHẠY CHÍNH
// =========================================================

// YÊU CẦU 2: Tiêm EmailNotification vào hệ thống
INotificationService emailSender = new EmailNotification();
TransactionService emailSystem = new TransactionService(emailSender); // Khởi tạo TransactionService và tiêm emailSender vào
emailSystem.Execute(500000);

Console.WriteLine("-----------------------------");

// YÊU CẦU 3: Tiêm SmsNotification vào hệ thống
INotificationService smsSender = new SmsNotification();
TransactionService smsSystem = new TransactionService(smsSender); // Khởi tạo TransactionService và tiêm smsSender vào
smsSystem.Execute(200000);


// =========================================================
// PHẦN 2: CÁC THÀNH PHẦN KIẾN TRÚC (HOÀN THÀNH CLASS TransactionService)
// =========================================================

public interface INotificationService
{
    void SendMessage(string message);
}

public class EmailNotification : INotificationService
{
    public void SendMessage(string message) => Console.WriteLine($"[EMAIL SENT]: {message}");
}

public class SmsNotification : INotificationService
{
    public void SendMessage(string message) => Console.WriteLine($"[SMS SENT]: {message}");
}

// YÊU CẦU 1: Hoàn thiện Class này
public class TransactionService
{
    // Khai báo một biến private readonly để giữ bản hợp đồng
    private readonly INotificationService _inotificationservice;

    // Viết Constructor nhận vào INotificationService và gán cho biến ở trên
    public TransactionService(INotificationService inotificationService)
    {
        _inotificationservice = inotificationService;
    }

    public void Execute(decimal amount)
    {
        Console.WriteLine($"Giao dich tru tien: {amount} VND thanh cong.");
        // Gọi hàm SendMessage từ biến interface để thông báo "Tai khoan bi tru tien."
        _inotificationservice.SendMessage("Tai khoan bi tru tien.");
    }
}