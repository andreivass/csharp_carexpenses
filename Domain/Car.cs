using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Car
    {
        public int CarId { get; set; }
        
        [MaxLength(128)] public string CarPlate { get; set; } = default!;
        
        [MaxLength(128)] public string CarMake { get; set; } = default!;
        
        [MaxLength(128)] public string CarModel { get; set; } = default!;
        
        [MaxLength(1000)] public string Description { get; set; } = default!;
        
        public int CarYear { get; set; }

        public string FuelId { get; set; } = default!;
        public Fuel Fuel { get; set; } = default!;
        
        public int CarCurrentMileage { get; set; }
        public int CarInitialMileage { get; set; }

        public ICollection<Expense> CarExpenses { get; set; } = default!;

    }
}