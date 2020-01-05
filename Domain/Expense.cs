using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Expense
    {
        [Display(Name = "Expense")]
        public int ExpenseId { get; set; }
        
        [Display(Name = "Title")]
        [MaxLength(128)] public string ExpenseName { get; set; } = default!;
        
        [Display(Name = "Cost in €")]
        public float ExpenseCostEur { get; set; }
        [Display(Name = "Quantity")]
        public float ExpenseQuantity { get; set; }

        [Display(Name = "Expense")]
        public int ExpenseTypeId { get; set; }
        public ExpenseType? ExpenseType { get; set; }
        
        [Display(Name = "Unit")]
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }
        
        [Display(Name = "Car")]
        public int CarId { get; set; }
        public Car? Car { get; set; }

        [Display(Name = "ODO  at expense")]
        public int CarMileage { get; set; }
        
        [Display(Name = "Time of entry")]
        public DateTime ExpenseTime { get; set; }
        
    }
}