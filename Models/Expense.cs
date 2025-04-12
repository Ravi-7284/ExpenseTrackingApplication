using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackingApplication.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
