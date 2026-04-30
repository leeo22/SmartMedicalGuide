namespace SmartMedicalGuide.Core.Features.Users.Queries.Results
{
    public class GetSingleUserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public bool IsVerified { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
