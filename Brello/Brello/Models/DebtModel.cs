using System;

namespace Brello.Models
{
    public class Debt
    {
        public int Id { get; set; } // Primary key
        public string Source { get; set; } = string.Empty; // Source of the debt
        public decimal Amount { get; set; } // Amount of the debt
        public DateTime DebtDueDate { get; set; } // Due date for the debt
        public string Status { get; set; } = "Pending"; // Status of the debt (default: Pending)
    }
}
