using Expense_Tracker.Common.Entities;
using Expense_Tracker.Repository.Context;
using Expense_Tracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expense_Tracker.Repository.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;
        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Expense?> GetByIdAsync(string id) => await _context.Expenses.FindAsync(id);

        public async Task<IEnumerable<Expense>> GetAllAsync() => await _context.Expenses.ToListAsync();

        public async Task AddAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expense expense)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}
