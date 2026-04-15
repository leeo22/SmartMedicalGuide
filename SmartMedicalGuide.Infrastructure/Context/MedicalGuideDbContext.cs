using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;


namespace SmartMedicalGuide.Infrastructure.Context
{
    public class MedicalGuideDbContext : DbContext
    {
        public MedicalGuideDbContext(DbContextOptions<MedicalGuideDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<LabService> LabServices { get; set; }
        public DbSet<LabAppointment> LabAppointments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AppointmentHistory> AppointmentHistories { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<VerificationRequest> VerificationRequests { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Role → User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2. User → Patient (One-to-One)
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3. User → Doctor (One-to-One)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 4. User → Lab (One-to-One)
            modelBuilder.Entity<Lab>()
                .HasOne(l => l.User)
                .WithOne(u => u.Lab)
                .HasForeignKey<Lab>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 5. Doctor → Specialization
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialization)
                .WithMany()
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.SetNull);

            // 6. Doctor → Clinic
            modelBuilder.Entity<Clinic>()
                .HasOne(c => c.Doctor)
                .WithMany(d => d.Clinics)
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            // 7. Clinic → User
            modelBuilder.Entity<Clinic>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 8. Doctor → DoctorSchedule
            modelBuilder.Entity<DoctorSchedule>()
                .HasOne(ds => ds.Doctor)
                .WithMany()
                .HasForeignKey(ds => ds.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            // 9. Patient → DoctorAppointment
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(da => da.Patient)
                .WithMany(p => p.DoctorAppointments)
                .HasForeignKey(da => da.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 10. Doctor → DoctorAppointment
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(da => da.Doctor)
                .WithMany()
                .HasForeignKey(da => da.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // 11. Payment → DoctorAppointment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.DoctorAppointment)
                .WithOne(da => da.Payment)
                .HasForeignKey<Payment>(p => p.DoctorAppointmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // 12. Payment → LabAppointment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.LabAppointment)
                .WithOne(la => la.Payment)
                .HasForeignKey<Payment>(p => p.LabAppointmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // 13. Patient → LabAppointment
            modelBuilder.Entity<LabAppointment>()
                .HasOne(la => la.Patient)
                .WithMany(p => p.LabAppointments)
                .HasForeignKey(la => la.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 14. Lab → LabAppointment
            modelBuilder.Entity<LabAppointment>()
                .HasOne(la => la.Lab)
                .WithMany()
                .HasForeignKey(la => la.LabId)
                .OnDelete(DeleteBehavior.Restrict);

            // 15. Lab → LabService
            modelBuilder.Entity<LabService>()
                .HasOne(ls => ls.Lab)
                .WithMany(l => l.LabServices)
                .HasForeignKey(ls => ls.LabId)
                .OnDelete(DeleteBehavior.Cascade);

            // 16. Prescription → DoctorAppointment
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.DoctorAppointment)
                .WithMany()
                .HasForeignKey(p => p.DoctorAppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // 17. PrescriptionItem → Prescription
            modelBuilder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.Prescription)
                .WithMany()
                .HasForeignKey(pi => pi.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            // 18. Chat → Patient
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 19. Chat → Doctor
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // 20. Message → Chat
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            // 21. Message → Sender
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // 22. Favorite (Unique Constraint)
            modelBuilder.Entity<Favorite>()
                .HasIndex(f => new { f.PatientId, f.DoctorId })
                .IsUnique();

            // 23. Notification → User
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 24. AuditLog → User
            modelBuilder.Entity<AuditLog>()
                .HasOne(al => al.User)
                .WithMany()
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 25. Attachment → User
            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 26. Wallet → User
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithOne()
                .HasForeignKey<Wallet>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 27. Transaction → Wallet
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany()
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            // 28. VerificationRequest → User
            modelBuilder.Entity<VerificationRequest>()
                .HasOne(vr => vr.User)
                .WithMany()
                .HasForeignKey(vr => vr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 29. Report → ReporterUser
            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReporterUser)
                .WithMany()
                .HasForeignKey(r => r.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 30. UserSession → User
            modelBuilder.Entity<UserSession>()
                .HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 31. SearchHistory → User
            modelBuilder.Entity<SearchHistory>()
                .HasOne(sh => sh.User)
                .WithMany()
                .HasForeignKey(sh => sh.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Ignore<string>();
        }
    }


}
