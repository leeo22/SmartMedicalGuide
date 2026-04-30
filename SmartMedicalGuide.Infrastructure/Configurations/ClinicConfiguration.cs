using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            // 6. Doctor → Clinic

            builder.HasOne(c => c.Doctor)
                   .WithMany(d => d.Clinics)
                   .HasForeignKey(c => c.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 7. Clinic → User

            builder.HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
