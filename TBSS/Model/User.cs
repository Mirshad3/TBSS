namespace TBSS.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int CustomerId { get; set; }
        public List<ProjectUser> Projects { get; set; } = new List<ProjectUser>();
    }

    public class ProjectUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }

}
