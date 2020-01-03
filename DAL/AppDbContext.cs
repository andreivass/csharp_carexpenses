using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Fuel> Fuels { get; set; } = default!;
        public DbSet<Expense> Expenses { get; set; } = default!;
        public DbSet<ExpenseType> ExpenseTypes { get; set; } = default!;
        public DbSet<Unit> Units { get; set; } = default!;

        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }
    }
}