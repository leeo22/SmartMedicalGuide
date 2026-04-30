using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class DoctorAppointmentConfiguration : IEntityTypeConfiguration<DoctorAppointment>
    {
        public void Configure(EntityTypeBuilder<DoctorAppointment> builder)
        {
            // 9. Patient → DoctorAppointment

            builder.HasOne(da => da.Patient)
                   .WithMany(p => p.DoctorAppointments)
                   .HasForeignKey(da => da.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 10. Doctor → DoctorAppointment

            builder.HasOne(da => da.Doctor)
                   .WithMany()
                   .HasForeignKey(da => da.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
