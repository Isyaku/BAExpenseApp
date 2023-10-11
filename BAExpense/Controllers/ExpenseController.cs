using BAExpense.Data;
using BAExpense.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BAExpense.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext db;
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(ExpenseDbContext db, ILogger<ExpenseController> logger )
        {
            this.db = db;
            _logger = logger;
        }

        // All Expense
        public IActionResult Index()
        {
            IEnumerable<Expense> objectList = db.Expenses;
            return View(objectList);
        }

        // Get Create
        public IActionResult Create()
        {
            return View();
        }
        // Post Create
        [HttpPost]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
