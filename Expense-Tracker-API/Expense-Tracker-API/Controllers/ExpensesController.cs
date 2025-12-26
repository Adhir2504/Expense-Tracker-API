using Expense_Tracker.Common.Entities;
using Expense_Tracker.Common.Models;
using Expense_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Expense_Tracker_API.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _service;
        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            var list = await _service.GetAllExpensesAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = nameof(GetExpenseById))]
        public async Task<IActionResult> GetExpenseById(string id)
        {
            var expense = await _service.GetExpenseByIdAsync(id);
            if (expense == null) return NotFound();
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] ExpenseDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var expense = await _service.AddExpenseAsync(dto);
            return CreatedAtRoute(nameof(GetExpenseById), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(string id, [FromBody] Expense expense)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateExpenseAsync(id, expense);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(string id)
        {
            var deleted = await _service.DeleteExpenseAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
