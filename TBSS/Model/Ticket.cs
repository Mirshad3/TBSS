namespace TBSS.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public int AssigneeId { get; set; }
    }
}
