using Expense_Tracker.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IBudgetRepository
    {
        Task<Budget?> GetByIdAsync(int id);
        Task<IEnumerable<Budget>> GetAllAsync();
        Task<Budget?> GetByMonthYearAsync(int month, int year);
        Task AddAsync(Budget budget);
        Task UpdateAsync(Budget budget);
        Task DeleteAsync(Budget budget);
        Task<bool> ExistsAsync(int month, int year);
    }
}
