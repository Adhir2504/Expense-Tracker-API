using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Common.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LimitAmount { get; set; }

        public List<Expense>? Expenses { get; set; }
    }
}
