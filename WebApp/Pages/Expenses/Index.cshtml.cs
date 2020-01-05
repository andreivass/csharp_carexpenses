using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_Expenses
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync(string? onReset)
        {
            Expense = await _context.Expenses
                .Include(e => e.Car)
                .Include(e => e.ExpenseType)
                .Include(e => e.Unit).OrderByDescending(d => d.ExpenseTime).ToListAsync();
            
            if (onReset == "Reset")
            {
                SearchString = "";
            }
            
            
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                var filterCars = Expense.Where(s => s.Car.CarPlate.ToLower().Contains(SearchString.ToLower()));
                Expense = filterCars.ToList();
            }
        }
    }
}
