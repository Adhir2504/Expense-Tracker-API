using Expense_Tracker.Common.Entities;
using Expense_Tracker.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Services.Interfaces
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetBudgetsAsync(int? month, int? year);
        Task<Budget?> GetBudgetByIdAsync(int id);
        Task<(bool IsSuccess, string? ErrorMessage, Budget? Budget)> AddBudgetAsync(BudgetDTO dto);
        Task<Budget?> UpdateBudgetAsync(int id, BudgetDTO dto);
        Task<bool> DeleteBudgetAsync(int id);
    }
}
