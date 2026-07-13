

using Microsoft.AspNetCore.Mvc;

namespace MiniWalletAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTransactions()
        {
            var listTransactions = new List<TransactionRequest>
            {
                new TransactionRequest { TransactionId = "TXN-01", Amount = 100000, Type = "Deposit", Status = "Success" },
                new TransactionRequest { TransactionId = "TXN-02", Amount = 1000000, Type = "Withdraw", Status = "False" }
            };

            var response = new ApiResponse<List<TransactionRequest>>
            {
                IsSuccess = true,
                Data = listTransactions,
                ErrorMessage = null
            };

            return Ok(response);
        }


    }

    public class TransactionRequest
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}