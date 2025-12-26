using Expense_Tracker.Common.Entities;
using Expense_Tracker.Repository.Context;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Repository.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly DataContext _context;
        public BudgetRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Budget?> GetByIdAsync(int id) => await _context.Budgets.FindAsync(id);

        public async Task<IEnumerable<Budget>> GetAllAsync() => await _context.Budgets.ToListAsync();

        public async Task<Budget?> GetByMonthYearAsync(int month, int year) =>
            await _context.Budgets.FirstOrDefaultAsync(b => b.Month == month && b.Year == year);

        public async Task AddAsync(Budget budget)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Budget budget)
        {
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int month, int year) =>
            await _context.Budgets.AnyAsync(b => b.Month == month && b.Year == year);
    }
}
