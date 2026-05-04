using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class DoctorCapacitySettingConfiguration : IEntityTypeConfiguration<DoctorCapacitySetting>
    {
        public void Configure(EntityTypeBuilder<DoctorCapacitySetting> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DoctorId).IsRequired();

            // ✅ تخزين Enum كـ string في قاعدة البيانات (لقراءة أفضل)
            builder.Property(x => x.WorkDays)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.BookingType)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.ShiftType)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
