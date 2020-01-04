using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Unit
    {
        public int UnitId { get; set; }
        
        [Display(Name = "Unit")]
        [MaxLength(128)] public string UnitName { get; set; } = default!;

        public ICollection<Expense>? Expenses { get; set; }
        
        [Display(Name = "Time of entry")]
        public DateTime UnitTime { get; set; }
    }
}