namespace SmartMedicalGuide.Data.Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
