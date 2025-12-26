using Expense_Tracker.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Repository.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense?> GetByIdAsync(string id);
        Task<IEnumerable<Expense>> GetAllAsync();
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(Expense expense);
    }
}
