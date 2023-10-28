using BAExpense.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BAExpense.Data
{
    public class ExpenseDbContext : IdentityDbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
    } 
}
