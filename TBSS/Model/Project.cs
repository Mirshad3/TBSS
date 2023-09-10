 

namespace TBSS.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public List<ProjectUser> Users { get; set; } = new List<ProjectUser>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }

}
