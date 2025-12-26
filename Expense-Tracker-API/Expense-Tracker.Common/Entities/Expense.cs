using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Common.Entities
{
    public class Expense
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Category { get; set; } = string.Empty;
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? BudgetId { get; set; }
        public Budget? Budget { get; set; }
    }
}
