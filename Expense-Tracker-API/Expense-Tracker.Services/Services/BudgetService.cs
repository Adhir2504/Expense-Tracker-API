using Expense_Tracker.Common.Entities;
using Expense_Tracker.Common.Models;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Services.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _repository;

        public BudgetService(IBudgetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync(int? month, int? year)
        {
            if (month.HasValue && year.HasValue)
            {
                var budget = await _repository.GetByMonthYearAsync(month.Value, year.Value);
                return budget != null ? new List<Budget> { budget } : new List<Budget>();
            }

            return await _repository.GetAllAsync();
        }

        public async Task<Budget?> GetBudgetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage, Budget? Budget)> AddBudgetAsync(BudgetDTO dto)
        {
            if (!dto.Month.HasValue || !dto.Year.HasValue)
                return (false, "Month and Year are required.", null);

            if (await _repository.ExistsAsync(dto.Month.Value, dto.Year.Value))
                return (false, "Budget for this month/year already exists.", null);

            var budget = new Budget
            {
                Month = dto.Month.Value,
                Year = dto.Year.Value,
                LimitAmount = dto.LimitAmount
            };

            await _repository.AddAsync(budget);
            return (true, null, budget);
        }

        public async Task<Budget?> UpdateBudgetAsync(int id, BudgetDTO dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            // Only update Month/Year if they are explicitly provided
            if (dto.Month.HasValue)
                existing.Month = dto.Month.Value;

            if (dto.Year.HasValue)
                existing.Year = dto.Year.Value;

            // Always update limitAmount
            existing.LimitAmount = dto.LimitAmount;

            await _repository.UpdateAsync(existing);
            return existing;
        }


        public async Task<bool> DeleteBudgetAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }
    }
}
