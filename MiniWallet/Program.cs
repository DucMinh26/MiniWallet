

var mockTransactions = new List<Transaction>
{
    new Transaction { Id = Guid.NewGuid(), Amount = 1000, Type = "Withdraw", IsSuccess = false, CreatedAt = DateTime.Now },
    new Transaction { Id = Guid.NewGuid(), Amount = 200, Type = "Withdraw", IsSuccess = false, CreatedAt = DateTime.Now },
    new Transaction { Id = Guid.NewGuid(), Amount = 1500, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now },
    new Transaction { Id = Guid.NewGuid(), Amount = 600, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now },
    new Transaction { Id = Guid.NewGuid(), Amount = 800, Type = "Withdraw", IsSuccess = false, CreatedAt = DateTime.Now },

    new Transaction { Id = Guid.NewGuid(), Amount = 2500, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-5) },
    new Transaction { Id = Guid.NewGuid(), Amount = 1200, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-10) },
    new Transaction { Id = Guid.NewGuid(), Amount = 3500, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-15) },
    new Transaction { Id = Guid.NewGuid(), Amount = 700, Type = "Withdraw", IsSuccess = false, CreatedAt = DateTime.Now.AddMinutes(-20) },
    new Transaction { Id = Guid.NewGuid(), Amount = 5000, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-25) },
    new Transaction { Id = Guid.NewGuid(), Amount = 300, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-30) },
    new Transaction { Id = Guid.NewGuid(), Amount = 1800, Type = "Deposit", IsSuccess = false, CreatedAt = DateTime.Now.AddMinutes(-35) },
    new Transaction { Id = Guid.NewGuid(), Amount = 950, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-40) },
    new Transaction { Id = Guid.NewGuid(), Amount = 2200, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-45) },
    new Transaction { Id = Guid.NewGuid(), Amount = 450, Type = "Withdraw", IsSuccess = false, CreatedAt = DateTime.Now.AddMinutes(-50) },
    new Transaction { Id = Guid.NewGuid(), Amount = 6700, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddMinutes(-55) },
    new Transaction { Id = Guid.NewGuid(), Amount = 1100, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddHours(-1) },
    new Transaction { Id = Guid.NewGuid(), Amount = 900, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddHours(-2) },
    new Transaction { Id = Guid.NewGuid(), Amount = 4000, Type = "Deposit", IsSuccess = false, CreatedAt = DateTime.Now.AddHours(-3) },
    new Transaction { Id = Guid.NewGuid(), Amount = 2750, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddHours(-4) },
    new Transaction { Id = Guid.NewGuid(), Amount = 650, Type = "Withdraw", IsSuccess = false, CreatedAt = DateTime.Now.AddHours(-5) },
    new Transaction { Id = Guid.NewGuid(), Amount = 7800, Type = "Deposit", IsSuccess = true, CreatedAt = DateTime.Now.AddHours(-6) },
    new Transaction { Id = Guid.NewGuid(), Amount = 1300, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddHours(-7) },
    new Transaction { Id = Guid.NewGuid(), Amount = 2100, Type = "Deposit", IsSuccess = false, CreatedAt = DateTime.Now.AddHours(-8) },
    new Transaction { Id = Guid.NewGuid(), Amount = 550, Type = "Withdraw", IsSuccess = true, CreatedAt = DateTime.Now.AddHours(-9) }
};

var biggestDeposit = mockTransactions
                        .Where(t => t.Type == "Deposit")
                        .OrderByDescending(t => t.Amount)
                        .FirstOrDefault();

var sortedWithdraw = mockTransactions
                        .Where(t => t.Type == "Withdraw")
                        .OrderByDescending(t => t.Amount)
                        .ThenByDescending(t => t.CreatedAt);


Console.WriteLine("---Ket qua---");
Console.WriteLine($"Id:{biggestDeposit.Id} | Amount:{biggestDeposit.Amount} | IsSuccess:{biggestDeposit.IsSuccess} | CreateAt:{biggestDeposit.CreatedAt}");
Console.WriteLine("--------------------------------");
foreach (var item in sortedWithdraw)
{
    Console.WriteLine($"Id:{item.Id} | Amount:{item.Amount} | IsSuccess:{item.IsSuccess} | CreateAt:{item.CreatedAt}");
}
public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime CreatedAt { get; set; }
}
