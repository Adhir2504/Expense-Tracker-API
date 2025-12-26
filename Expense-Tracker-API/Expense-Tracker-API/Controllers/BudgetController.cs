using Expense_Tracker.Common.Entities;
using Expense_Tracker.Common.Models;
using Expense_Tracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_API.Controllers
{
    [Route("api/budgets")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetService _service;

        public BudgetsController(IBudgetService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBudgets([FromQuery] int? month, [FromQuery] int? year)
        {
            var budgets = await _service.GetBudgetsAsync(month, year);
            if (!budgets.Any()) return NotFound();
            return Ok(budgets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            var budget = await _service.GetBudgetByIdAsync(id);
            if (budget == null) return NotFound();
            return Ok(budget);
        }

        [HttpPost]
        public async Task<IActionResult> AddBudget([FromBody] BudgetDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (isSuccess, errorMessage, budget) = await _service.AddBudgetAsync(dto);
            if (!isSuccess) return Conflict(new { message = errorMessage });

            return CreatedAtAction(nameof(GetBudgetById), new { id = budget!.Id }, budget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(int id, [FromBody] BudgetDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateBudgetAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            var deleted = await _service.DeleteBudgetAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
