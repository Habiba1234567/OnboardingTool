namespace onboarding_tool.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }


    }
}
