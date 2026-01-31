using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;


namespace SmartMedicalGuide.Infrastructure.Context
{
    public class MedicalGuideDbContext : DbContext
    {
        public MedicalGuideDbContext(DbContextOptions<MedicalGuideDbContext> options)
            : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Lab> Lab { get; set; }
        public DbSet<VerificationRequest> VerificationRequest { get; set; }
        //public DbSet<Symptom> Symptom { get; set; }
        //public DbSet<SymptomDiagnosis> SymptomDiagnose { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointment { get; set; }
        public DbSet<LabAppointment> LabAppointment { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MedicalReport> MedicalReport { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<LabService> LabService { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Roles - Users
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users - Patient (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users - Doctor (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users - Lab (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Lab)
                .WithOne(l => l.User)
                .HasForeignKey<Lab>(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clinic - Doctors (1:M)
            modelBuilder.Entity<Clinic>()
                .HasOne(d => d.Doctor)
                .WithMany(c => c.Clinics)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lab - LabServices
            modelBuilder.Entity<LabService>()
                .HasOne(ls => ls.Lab)
                .WithMany(l => l.LabServices)
                .HasForeignKey(ls => ls.LabId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - VerificationRequests
            modelBuilder.Entity<VerificationRequest>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //// Symptoms - SymptomDiagnoses
            //modelBuilder.Entity<SymptomDiagnosis>()
            //    .HasOne(sd => sd.Symptom)
            //    .WithMany()
            //    .HasForeignKey(sd => sd.SymptomId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Patient - DoctorAppointments
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.DoctorAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor - DoctorAppointments
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Patient - LabAppointments
            modelBuilder.Entity<LabAppointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.LabAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lab - LabAppointments
            modelBuilder.Entity<LabAppointment>()
                .HasOne(a => a.Lab)
                .WithMany()
                .HasForeignKey(a => a.LabId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment - Payment (1:1)
            modelBuilder.Entity<Payment>()
                .Property(p => p.AppointmentType)
                .HasConversion<int>();

            modelBuilder.Entity<Payment>()
                .HasIndex(p => new { p.AppointmentType, p.AppointmentId })
                .IsUnique();


            // Chat relations
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Chat - Messages
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // MedicalReports
            modelBuilder.Entity<MedicalReport>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalReport>()
                .HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalReport>()
                .HasOne<Lab>()
                .WithMany()
                .HasForeignKey(m => m.LabId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prescriptions
            modelBuilder.Entity<Prescription>()
                .HasOne<DoctorAppointment>()
                .WithOne()
                .HasForeignKey<Prescription>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Notifications
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reviews
            modelBuilder.Entity<Review>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // AuditLogs
            modelBuilder.Entity<AuditLog>()

                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reports (بلاغات)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReporterUser)
                .WithMany()
                .HasForeignKey(r => r.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }


}
