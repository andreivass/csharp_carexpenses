using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        [MaxLength(128)] public string ExpenseName { get; set; } = default!;

        public float ExpenseCostEur { get; set; }
        public float ExpenseQuantity { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType? ExpenseType { get; set; }

        public int UnitId { get; set; }
        public Unit? Unit { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public int CarMileage { get; set; }
        
        
        
    }
}