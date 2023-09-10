using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetTickets(int? customerId, int? projectId, int? userId, string status)
        {
            IQueryable<Ticket> query = _context.Tickets;

            if (customerId.HasValue)
                query = query.Where(t => t.CustomerId == customerId);

            if (projectId.HasValue)
                query = query.Where(t => t.ProjectId == projectId);

            if (userId.HasValue)
                query = query.Where(t => t.AssigneeId == userId);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(t => t.Status == status);

            return query.ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _context.Tickets.FirstOrDefault(t => t.Id == id);
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public bool DeleteTicket(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
                return false;

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return true;
        }
    }
}