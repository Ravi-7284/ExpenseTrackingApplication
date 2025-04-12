using ExpenseTrackingApplication.Data;
using ExpenseTrackingApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingApplication.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new ExpenseViewModel
            {
                NewExpense = new Expense(),
                Expenses = _context.Expenses.OrderByDescending(e => e.CreatedAt).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(ExpenseViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(model.NewExpense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Expenses = _context.Expenses.OrderByDescending(e => e.CreatedAt).ToList();
            return View("Index", model);
        }

        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
