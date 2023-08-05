namespace OnboardingTool.Models.Domain
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int Role_id { get; set; }
        public int age { get; set; }
        public int phoneNum { get; set; }
        public string job_title { get; set; }
        public DateTime enrollment_date { get; set; }
        public ICollection<log> logs { get; set; }
        public ICollection<User_courses> course { get; } = new List<User_courses>();
        public ICollection<User_roles> roles { get; } = new List<User_roles>();

    }



}
