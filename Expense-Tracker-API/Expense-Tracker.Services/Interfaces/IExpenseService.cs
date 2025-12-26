using Expense_Tracker.Common.Entities;
using Expense_Tracker.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(string id);
        Task<Expense> AddExpenseAsync(ExpenseDTO dto);
        Task<Expense?> UpdateExpenseAsync(string id, Expense expense);
        Task<bool> DeleteExpenseAsync(string id);
    }
}
