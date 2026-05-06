using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;

namespace SmartMedicalGuide.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            UserRefreshToken = new HashSet<UserRefreshToken>();
        }

        public string? FullName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        [EncryptColumn]
        public string? Code { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Lab? Lab { get; set; }
        public virtual ICollection<UserRefreshToken> UserRefreshToken { get; set; }
    }

}
