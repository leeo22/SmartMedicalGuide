using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(x => x.FavoriteId);

            // علاقة Favorites مع Patient - بدون Cascade Delete
            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);  // ✅ Restrict بدلاً من Cascade

            // علاقة Favorites مع Doctor - بدون Cascade Delete
            builder.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);  // ✅ Restrict بدلاً من Cascade

            // Favorite (Unique Constraint)
            builder
                 .HasIndex(f => new { f.PatientId, f.DoctorId })
                 .IsUnique();
        }
    }
}
