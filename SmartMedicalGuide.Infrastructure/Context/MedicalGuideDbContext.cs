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
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<VerificationRequest> VerificationRequests { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<SymptomDiagnosis> SymptomDiagnoses { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<LabAppointment> LabAppointments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<LabService> LabServices { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Roles - Users
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Users - Patient (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId);

            // Users - Doctor (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId);

            // Users - Lab (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Lab)
                .WithOne(l => l.User)
                .HasForeignKey<Lab>(l => l.UserId);

            // Clinic - Doctors (1:M)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.ClinicId);

            // Lab - LabServices
            modelBuilder.Entity<LabService>()
                .HasOne(ls => ls.Lab)
                .WithMany(l => l.LabServices)
                .HasForeignKey(ls => ls.LabId);

            // User - VerificationRequests
            modelBuilder.Entity<VerificationRequest>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId);

            // Symptoms - SymptomDiagnoses
            modelBuilder.Entity<SymptomDiagnosis>()
                .HasOne(sd => sd.Symptom)
                .WithMany()
                .HasForeignKey(sd => sd.SymptomId);

            // Patient - DoctorAppointments
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.DoctorAppointments)
                .HasForeignKey(a => a.PatientId);

            // Doctor - DoctorAppointments
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);

            // Patient - LabAppointments
            modelBuilder.Entity<LabAppointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.LabAppointments)
                .HasForeignKey(a => a.PatientId);

            // Lab - LabAppointments
            modelBuilder.Entity<LabAppointment>()
                .HasOne(a => a.Lab)
                .WithMany()
                .HasForeignKey(a => a.LabId);

            // Appointment - Payment (1:1)
            modelBuilder.Entity<DoctorAppointment>()
                .HasOne(a => a.Payment)
                .WithOne()
                .HasForeignKey<Payment>(p => p.AppointmentId);

            modelBuilder.Entity<LabAppointment>()
                .HasOne(a => a.Payment)
                .WithOne()
                .HasForeignKey<Payment>(p => p.AppointmentId);

            // Chat relations
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId);

            // Chat - Messages
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId);

            // MedicalReports
            modelBuilder.Entity<MedicalReport>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(m => m.PatientId);

            modelBuilder.Entity<MedicalReport>()
                .HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(m => m.DoctorId);

            modelBuilder.Entity<MedicalReport>()
                .HasOne<Lab>()
                .WithMany()
                .HasForeignKey(m => m.LabId);

            // Prescriptions
            modelBuilder.Entity<Prescription>()
                .HasOne<DoctorAppointment>()
                .WithOne()
                .HasForeignKey<Prescription>(p => p.AppointmentId);

            // Notifications
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);

            // Reviews
            modelBuilder.Entity<Review>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(r => r.PatientId);

            // AuditLogs
            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId);

            // Reports (بلاغات)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReporterUser)
                .WithMany()
                .HasForeignKey(r => r.ReporterUserId);
        }

    }


}
