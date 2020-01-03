using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ExpenseType
    {
        public int ExpenseTypeId { get; set; }

        [MaxLength(128)] public string ExpenseTypeName { get; set; } = default!;

        public ICollection<Expense> Expenses { get; set; } = default!;
    }
}