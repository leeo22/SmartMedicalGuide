using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class LabAppointmentConfiguration : IEntityTypeConfiguration<LabAppointment>
    {
        public void Configure(EntityTypeBuilder<LabAppointment> builder)
        {
            // 13. Patient → LabAppointment

            builder.HasOne(la => la.Patient)
                   .WithMany(p => p.LabAppointments)
                   .HasForeignKey(la => la.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 14. Lab → LabAppointment

            builder.HasOne(la => la.Lab)
                   .WithMany()
                   .HasForeignKey(la => la.LabId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
