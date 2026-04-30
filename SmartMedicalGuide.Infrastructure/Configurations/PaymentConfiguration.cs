using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // 11. Payment → DoctorAppointment

            builder.HasOne(p => p.DoctorAppointment)
                   .WithOne(da => da.Payment)
                   .HasForeignKey<Payment>(p => p.DoctorAppointmentId)
                   .OnDelete(DeleteBehavior.SetNull);

            // 12. Payment → LabAppointment

            builder.HasOne(p => p.LabAppointment)
                   .WithOne(la => la.Payment)
                   .HasForeignKey<Payment>(p => p.LabAppointmentId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
