using Microsoft.AspNetCore.Mvc;
using MiniWalletAPI.Data;

namespace MiniWalletAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetActionResultById([FromRoute] string id)
        {
            var transaction = new TransactionRequest
            {
                TransactionId = id,
                Amount = 50000,
                Type = "Deposit",
                Status = "Success"
            };

            var response = new ApiResponse<TransactionRequest>
            {
                IsSuccess = true,
                Data = transaction,
                ErrorMessage = null
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateTransaction([FromBody] TransactionRequest request)
        {
            if (request.Amount < 0)
            {
                var errormessage = new ApiResponse<object>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = "tien khong duoc < 0"
                };

                return BadRequest(errormessage);
            }

            var newTransaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                Type = request.Type,
                Status = "Pending",
                CreatedAt = DateTime.Now
            };

            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();

            return Ok(new ApiResponse<Transaction>
            {
                IsSuccess = true,
                Data = newTransaction,
                ErrorMessage = null
            });
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