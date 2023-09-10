using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers(int? customerId, int? projectId)
        {
            IQueryable<User> query = _context.Users;

            if (customerId.HasValue)
                query = query.Where(u => u.CustomerId == customerId);

            if (projectId.HasValue)
                query = query.Where(u => u.Projects.Any(p => p.ProjectId == projectId));

            return query.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}