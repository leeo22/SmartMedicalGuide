using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // 3. User → Doctor (One-to-One)

            builder.HasOne(d => d.User)
            .WithOne(u => u.Doctor)
            .HasForeignKey<Doctor>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            // 5. Doctor → Specialization

            builder.HasOne(d => d.Specialization)
            .WithMany()
            .HasForeignKey(d => d.SpecializationId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
