using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_Cars
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get; set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        
        public string? CarMakeSort { get; set; }
        public string? CarModelSort { get; set; }
        public string? CarPlateSort { get; set; }

        public async Task OnGetAsync(string? onReset, string? sortOrder)
        {
            CarPlateSort = string.IsNullOrEmpty(sortOrder) ? "plate_sort" : "";
            CarMakeSort = sortOrder == "make_sort" ? "make_desc" : "make_sort";
            CarModelSort = sortOrder == "model_sort" ? "model_desc" : "model_sort";

            switch (@sortOrder)
            {
                case "make_sort":
                    Cars = await _context.Cars
                        .Include(c => c.Fuel).OrderBy(s => s.CarMake).ToListAsync();
                    break;
                case "make_desc":
                    Cars = await _context.Cars
                        .Include(c => c.Fuel).OrderByDescending(s => s.CarMake).ToListAsync();
                    break;
                case "model_sort":
                    Cars = await _context.Cars
                        .Include(c => c.Fuel).OrderBy(s => s.CarModel).ToListAsync();
                    break;
                case "model_desc":
                    Cars = await _context.Cars
                        .Include(c => c.Fuel).OrderByDescending(s => s.CarModel).ToListAsync();
                    break;
                case "plate_sort":
                    Cars = await _context.Cars
                        .Include(c => c.Fuel).OrderByDescending(s => s.CarPlate).ToListAsync();
                    break;
                default:
                    Cars = await _context.Cars
                        .Include(c => c.Fuel).OrderBy(s => s.CarPlate).ToListAsync();
                    break;
            }
            
            if (onReset == "Reset")
            {
                SearchString = "";
            }
            
            
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                var filterCars = Cars.Where(s => s.CarPlate.ToLower().Contains(SearchString.ToLower()));
                Cars = filterCars.ToList();
            }
        }
    }
}
