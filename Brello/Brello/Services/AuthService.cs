using Brello.Models;
using Brello.Services;
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

        public async Task<bool> RegisterAsync(string username, string password)
        {
            try
            {
                // Check if the username already exists in the database
                bool userExists = await _context.Users.AnyAsync(u => u.Username == username);
                Console.WriteLine($"Checking if username exists: {userExists}");

                if (userExists)
                {
                    return false; // Username already exists
                }

                // Create a new user and save to the database
                var user = new User()
                {
                    Username = username,
                    Password = password // You should ideally hash the password before saving
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
    }
}
