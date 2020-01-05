using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages_Expenses
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarPlate");
        // ViewData["CarOdo"] = new SelectList(_context.Cars, "CarOdo", "CarCurrentMileage");
        ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypeId", "ExpenseTypeName");
        ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName");
            return Page();
        }

        [BindProperty] public Expense Expense { get; set; } = default!;

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var expenseOdo = Expense.CarMileage;
            var car = _context.Cars.Where(c => c.CarId == Expense.CarId).ToList();
            car[0].CarCurrentMileage = expenseOdo;
            
            _context.Cars.Update(car[0]);
            await _context.SaveChangesAsync();
            
            Expense.ExpenseTime = DateTime.Now;

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
