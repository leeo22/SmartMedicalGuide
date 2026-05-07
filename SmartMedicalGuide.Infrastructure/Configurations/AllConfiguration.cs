using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            //  User → Patient (One-to-One)
            builder
                 .HasOne(p => p.User)
                 .WithOne(u => u.Patient)
                 .HasForeignKey<Patient>(p => p.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            //  Doctor → DoctorSchedule
            builder
                 .HasOne(ds => ds.Doctor)
                 .WithMany()
                 .HasForeignKey(ds => ds.DoctorId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class LabConfiguration : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            //  User → Lab (One-to-One)
            builder
                 .HasOne(l => l.User)
                .WithOne(u => u.Lab)
                .HasForeignKey<Lab>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class LabServiceConfiguration : IEntityTypeConfiguration<LabService>
    {
        public void Configure(EntityTypeBuilder<LabService> builder)
        {
            // Lab → LabService
            builder
                .HasOne(ls => ls.Lab)
                .WithMany(l => l.LabServices)
                .HasForeignKey(ls => ls.LabId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(x => x.PrescriptionId);

            // العلاقة مع DoctorAppointment (مع Cascade)
            builder.HasOne(x => x.DoctorAppointment)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.DoctorAppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // العلاقة مع Doctor
            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ العلاقة مع Patient - استخدام Restrict بدلاً من Cascade
            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);  // ← هنا الحل

            builder.HasIndex(x => x.IsDeleted);
            builder.HasIndex(x => x.Status);

        }
    }
    public class PrescriptionItemConfiguration : IEntityTypeConfiguration<PrescriptionItem>
    {
        public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
        {
            // PrescriptionItem → Prescription
            builder
                 .HasOne(pi => pi.Prescription)
                 .WithMany()
                 .HasForeignKey(pi => pi.PrescriptionId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Notification → User
            builder
                 .HasOne(n => n.User)
                 .WithMany()
                 .HasForeignKey(n => n.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            // 24. AuditLog → User
            builder
                 .HasOne(al => al.User)
                 .WithMany()
                 .HasForeignKey(al => al.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            // 25. Attachment → User
            builder
                 .HasOne(a => a.User)
                 .WithMany()
                 .HasForeignKey(a => a.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            // 26. Wallet → User
            builder
                 .HasOne(w => w.User)
                 .WithOne()
                 .HasForeignKey<Wallet>(w => w.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            // 27. Transaction → Wallet
            builder
                 .HasOne(t => t.Wallet)
                 .WithMany()
                 .HasForeignKey(t => t.WalletId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class VerificationRequestConfiguration : IEntityTypeConfiguration<VerificationRequest>
    {
        public void Configure(EntityTypeBuilder<VerificationRequest> builder)
        { // 28. VerificationRequest → User
            builder
                 .HasOne(vr => vr.User)
                 .WithMany()
                 .HasForeignKey(vr => vr.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            // 29. Report → ReporterUser
            builder
                .HasOne(r => r.ReporterUser)
                .WithMany()
                .HasForeignKey(r => r.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {

            // 30. UserSession → User
            builder
                .HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class SearchHistoryConfiguration : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {

            // 31. SearchHistory → User
            builder
                .HasOne(sh => sh.User)
                .WithMany()
                .HasForeignKey(sh => sh.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
