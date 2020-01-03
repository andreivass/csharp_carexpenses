using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Unit
    {
        public int UnitId { get; set; }
        
        [MaxLength(128)] public string UnitName { get; set; } = default!;

        public ICollection<Expense>? Expenses { get; set; }
    }
}