using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Fuel
    {
        public int FuelId { get; set; }
        
        [Display(Name = "Fuel")]
        [MaxLength(128)]public string FuelName { get; set; } = default!;
        
        public ICollection<Car>? Cars { get; set; }
        
        [Display(Name = "Time of entry")]
        public DateTime FuelTime { get; set; }

    }
}