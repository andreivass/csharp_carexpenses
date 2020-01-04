using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Car
    {
        public int CarId { get; set; }
        
        [Display(Name = "Plate nr")]
        [MaxLength(128)] public string CarPlate { get; set; } = default!;
        
        [Display(Name = "Make")]
        [MaxLength(128)] public string CarMake { get; set; } = default!;
        
        [Display(Name = "Model")]
        [MaxLength(128)] public string CarModel { get; set; } = default!;
        
        [Display(Name = "Descr")]
        [MaxLength(1000)] public string Description { get; set; } = default!;
        
        [Display(Name = "Model Yr")]
        public int CarYear { get; set; }

        public int FuelId { get; set; }
        [Display(Name = "Fuel type")]
        public Fuel? Fuel { get; set; }
        
        [Display(Name = "Current ODO")]
        public int CarCurrentMileage { get; set; }
        [Display(Name = "Initial ODO")]
        public int CarInitialMileage { get; set; }

        public ICollection<Expense>? CarExpenses { get; set; }
        
        [Display(Name = "Time of entry")]
        public DateTime CarTime { get; set; }
    }
}