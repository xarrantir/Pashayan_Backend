using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pashayan_Backend.Data;
using Pashayan_Backend.Models;

namespace Pashayan_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public TransactionsController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _fullStackDbContext.Transactions.ToListAsync();

            return Ok(transactions);
        }


        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transactionRequest)
        {
            transactionRequest.Id = Guid.NewGuid();
            await _fullStackDbContext.Transactions.AddAsync(transactionRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(transactionRequest);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTransaction([FromRoute] Guid id)
        {
            var transaction = await _fullStackDbContext.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);




        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTransaction([FromRoute] Guid id, Transaction updateTransactionRequest)
        {
          var transaction = await   _fullStackDbContext.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }
            transaction.CarId = updateTransactionRequest.CarId;
            transaction.Cost = updateTransactionRequest.Cost;
            transaction.PayMethod = updateTransactionRequest.PayMethod;
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(transaction);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] Guid id)
        {
            var transaction = await _fullStackDbContext.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }
         _fullStackDbContext.Remove(transaction);
         await _fullStackDbContext.SaveChangesAsync();
            return Ok(transaction);
        }

    }

}



