using Expense_Tracker.Common.Entities;
using Expense_Tracker.Common.Models;
using Expense_Tracker.Repository.Interfaces;
using Expense_Tracker.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Services.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;
        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync() => await _repository.GetAllAsync();

        public async Task<Expense?> GetExpenseByIdAsync(string id) => await _repository.GetByIdAsync(id);

        public async Task<Expense> AddExpenseAsync(ExpenseDTO dto)
        {
            var expense = new Expense
            {
                Amount = dto.Amount,
                Category = dto.Category,
                Note = dto.Note,
                Date = dto.Date
            };
            await _repository.AddAsync(expense);
            return expense;
        }

        public async Task<Expense?> UpdateExpenseAsync(string id, Expense expense)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Amount = expense.Amount;
            existing.Category = expense.Category;
            existing.Note = expense.Note;
            existing.Date = expense.Date;

            await _repository.UpdateAsync(existing);
            return existing;
        }

        public async Task<bool> DeleteExpenseAsync(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }
    }
}
