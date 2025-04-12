namespace ExpenseTrackingApplication.Models
{
    public class ExpenseViewModel
    {
        public Expense NewExpense { get; set; } = new Expense();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
