using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class MedicalReportConfiguration : IEntityTypeConfiguration<MedicalReport>
    {
        public void Configure(EntityTypeBuilder<MedicalReport> builder)
        {
            builder.HasKey(x => x.ReportId);

            // ✅ تعديل: العلاقات أصبحت اختيارية
            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Lab)
                .WithMany()
                .HasForeignKey(x => x.LabId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}