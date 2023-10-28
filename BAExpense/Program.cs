using BAExpense.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ExpenseDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaulConnection")
    ));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ExpenseDbContext>();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Authentication/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expense}/{action=Index}/{id?}");

app.Run();
