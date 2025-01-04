namespace Brello.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now; // Default to current date
    }

    public enum TransactionType
    {
        Credit,
        Debit
    }
}
