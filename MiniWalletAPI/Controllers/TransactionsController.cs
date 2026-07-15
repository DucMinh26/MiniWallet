using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactionFromDb = await _context.Transactions.ToListAsync();

            if (transactionFromDb == null)
            {
                return NotFound();
            }

            var result = new ApiResponse<List<Transaction>>
            {
                IsSuccess = true,
                Data = transactionFromDb,
                ErrorMessage = null
            };

            return Ok(transactionFromDb);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActionResultById([FromRoute] Guid id)
        {
            var transactionId = await _context.Transactions.FindAsync(id);

            if (transactionId == null)
            {
                return NotFound();
            }
            var response = new ApiResponse<Transaction>
            {
                IsSuccess = true,
                Data = transactionId,
                ErrorMessage = null
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequest request)
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
            await _context.SaveChangesAsync();

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