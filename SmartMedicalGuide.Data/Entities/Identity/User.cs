using Microsoft.AspNetCore.Identity;

namespace SmartMedicalGuide.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        //[Key]
        //public int UserId { get; set; }
        public string? FullName { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string? Email { get; set; }
        //public string? Password { get; set; }

        //public int RoleId { get; set; }
        //public Role? Role { get; set; }

        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        // Navigations
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Lab? Lab { get; set; }
    }

}
