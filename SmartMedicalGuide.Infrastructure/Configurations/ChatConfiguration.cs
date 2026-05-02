using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            // العلاقة مع Patient
            builder
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // العلاقة مع Doctor
            builder
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ إضافة فهرس لتحسين البحث بآخر رسالة
            builder.HasIndex(c => c.LastMessageAt);

            // ✅ إضافة فهرس للبحث عن المحادثات النشطة
            builder.HasIndex(c => c.IsActive);
        }
    }
}