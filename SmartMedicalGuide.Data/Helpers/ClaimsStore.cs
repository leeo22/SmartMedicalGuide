using System.Security.Claims;

namespace SmartMedicalGuide.Data.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create User","false"),
            new Claim("Edit User","false"),
            new Claim("Delete User","false"),
        };
    }
}
