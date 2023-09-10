using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _context;

        public TicketController(ITicketRepository ticketService)
        {
            _context = ticketService;
        }

        [HttpGet]
        public IActionResult GetAllTickets([FromQuery] int? customerId, [FromQuery] int? projectId, [FromQuery] int? userId, [FromQuery] string status)
        {
            // Implement logic to get tickets with optional filters
            var tickets = _context.GetTickets(customerId, projectId, userId, status);
            return Ok(tickets);
        }
        [HttpGet("{id}")]
        public Ticket GetTicketById(int id)
        {
            return _context.GetTicketById(id);
        }
        [HttpPost]
        public Ticket CreateTicket(Ticket ticket)
        {
            _context.CreateTicket(ticket);
            return ticket;
        }
        [HttpPut]
        public Ticket UpdateTicket(Ticket ticket)
        {
            _context.UpdateTicket(ticket);
            return ticket;
        }
        [HttpDelete("{id}")]
        public bool DeleteTicket(int id)
        {
            var ticket = _context.GetTicketById(id);
            if (ticket == null)
                return false;

            _context.DeleteTicket(id);
            return true;
        }

    }
}
