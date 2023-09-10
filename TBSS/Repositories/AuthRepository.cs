using Microsoft.EntityFrameworkCore;
using System.Linq;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // Authentication successful
            return user;
        }

        // Helper method to verify password hash
        private bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
        {
            // Implement password hash verification logic
            // Example: Use a secure hashing algorithm like bcrypt or PBKDF2
            // Compare the computed hash with the stored hash
            // Return true if they match, otherwise false
            return true; // Replace with actual implementation
        }
    }
}