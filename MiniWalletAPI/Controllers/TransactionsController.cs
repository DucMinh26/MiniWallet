using System.ComponentModel.DataAnnotations;
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
            var transactionFromDb = await _context.Transactions
                                        .Select(t => new TransactionResponseDto
                                        {
                                            Amount = t.Amount,
                                            Type = t.Type,
                                            Status = t.Status
                                        }).ToListAsync();

            if (transactionFromDb == null)
            {
                return NotFound();
            }

            var result = new ApiResponse<List<TransactionResponseDto>>
            {
                IsSuccess = true,
                Data = transactionFromDb,
                ErrorMessage = null
            };

            return Ok(result);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransactionStatus([FromRoute] Guid id, [FromBody] UpdateStatusRequest request)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    IsSuccess = false,
                    ErrorMessage = "khong tim thay giao dich"
                });
            }

            transaction.Status = request.NewStatus;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<Transaction>
            {
                IsSuccess = true,
                Data = transaction,
                ErrorMessage = null
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetransaction([FromRoute] Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Data = null,
                    ErrorMessage = "khong tim thay user"
                });
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string>
            {
                IsSuccess = true,
                Data = "xoa thanh cong",
                ErrorMessage = null
            });
        }
    }



    public class TransactionRequest
    {
        [Range(1, double.MaxValue, ErrorMessage = "tien phai lon hon 0")]
        public decimal Amount { get; set; }
        [Required]
        public string Type { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class TransactionResponseDto
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }

    public class UpdateStatusRequest
    {
        public string NewStatus { get; set; }
    }
}