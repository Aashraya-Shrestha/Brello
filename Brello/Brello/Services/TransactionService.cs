using Brello.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brello.Services
{
    public class TransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        // Add a new transaction
        public async Task AddTransactionAsync(double amount, string description, TransactionType transactionType, DateTime TransactionDate)
        {
            try
            {
                var transaction = new Transaction
                {
                    Amount = amount,
                    Description = description,
                    TransactionType = transactionType,
                    TransactionDate = TransactionDate

                };
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding transaction: {ex.Message}");
            }
        }

        // Get all transactions
        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            try
            {
                return await _context.Transactions.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching transactions: {ex.Message}");
                return new List<Transaction>();
            }
        }

        // Get transactions by type
        public async Task<List<Transaction>> GetTransactionsByTypeAsync(TransactionType transactionType)
        {
            return await _context.Transactions
                .Where(t => t.TransactionType == transactionType)
                .ToListAsync();
        }

        public async Task DeleteTransactionAsync(int transactionId)
        {
            try
            {
                var transaction = await _context.Transactions.FindAsync(transactionId);
                if (transaction != null)
                {
                    _context.Transactions.Remove(transaction);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting transaction: {ex.Message}");
            }
        }

    }
}
