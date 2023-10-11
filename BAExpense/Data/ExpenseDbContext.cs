﻿using BAExpense.Models;
using Microsoft.EntityFrameworkCore;

namespace BAExpense.Data
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}