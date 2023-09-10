using TBSS.Model;

namespace TBSS.Repositories.IRepositories
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets(int? customerId, int? projectId, int? userId, string status);
        Ticket GetTicketById(int id);
        Ticket CreateTicket(Ticket ticket);
        Ticket UpdateTicket(Ticket ticket);
        bool DeleteTicket(int id);
    }
}
