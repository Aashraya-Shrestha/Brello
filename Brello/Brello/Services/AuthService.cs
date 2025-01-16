using Brello.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Brello.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(string username, string password, string preferredCurrency)
        {
            try
            {
                bool userExists = await _context.Users.AnyAsync(u => u.Username == username);
                if (userExists)
                {
                    return false; // Username already exists
                }

                var user = new User
                {
                    Username = username,
                    Password = password,
                    PreferredCurrency = preferredCurrency
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true; // Registration succeeded
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            return await _context.Users
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<string?> GetPreferredCurrencyAsync(string username)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.Username == username)
                    .Select(u => u.PreferredCurrency)
                    .FirstOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPreferredCurrencyAsync: {ex.Message}");
                return null;
            }
        }
    }
}
