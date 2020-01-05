using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ExpenseType
    {
        [Display(Name = "Expense type")]
        public int ExpenseTypeId { get; set; }
        
        [Display(Name = "Type")]
        [MaxLength(128)] public string ExpenseTypeName { get; set; } = default!;

        public ICollection<Expense>? Expenses { get; set; }
        
        [Display(Name = "Time of entry")]
        public DateTime ExpenseTypeTime { get; set; }
    }
}