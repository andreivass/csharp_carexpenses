using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        
        [Display(Name = "Title")]
        [MaxLength(128)] public string ExpenseName { get; set; } = default!;
        
        [Display(Name = "Cost in €")]
        public float ExpenseCostEur { get; set; }
        [Display(Name = "Qty")]
        public float ExpenseQuantity { get; set; }

        public int ExpenseTypeId { get; set; }
        [Display(Name = "Type")]
        public ExpenseType? ExpenseType { get; set; }

        public int UnitId { get; set; }
        public Unit? Unit { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        [Display(Name = "ODO  at expense")]
        public int CarMileage { get; set; }
        
        [Display(Name = "Time of entry")]
        public DateTime ExpenseTime { get; set; }
        
    }
}