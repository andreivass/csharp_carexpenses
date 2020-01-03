using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Fuel
    {
        public int FuelId { get; set; }

        [MaxLength(128)]public string FuelName { get; set; } = default!;
        
        public ICollection<Car> Cars { get; set; } = default!;

    }
}