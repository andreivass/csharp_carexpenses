using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_Cars
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; } = default!;
        [BindProperty] public int DrivenKm { get; set; } = default!;

        public ICollection<Expense> Expenses { get; set; } = default!;
        public float TotalCost { get; set; } = 0;
        public float TotalCost1km { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.Fuel).FirstOrDefaultAsync(m => m.CarId == id);

            DrivenKm = Car.CarCurrentMileage - Car.CarInitialMileage;
            
            Expenses = await _context.Expenses
                .Where(e => e.CarId == Car.CarId).ToListAsync();
            
            foreach (var expense in Expenses)
            {
                TotalCost += expense.ExpenseCostEur;
            }
            
            TotalCost1km = TotalCost / DrivenKm;

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
