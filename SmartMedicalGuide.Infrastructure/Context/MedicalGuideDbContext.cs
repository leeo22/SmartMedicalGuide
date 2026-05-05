using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Data.Entities.Identity;
using System.Reflection;


namespace SmartMedicalGuide.Infrastructure.Context
{
    public class MedicalGuideDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public MedicalGuideDbContext()
        {
        }


        public MedicalGuideDbContext(DbContextOptions<MedicalGuideDbContext> options)
            : base(options)
        {
            _encryptionProvider = new GenerateEncryptionProvider("9d4f6a8c2e1b5d7f9a3c6e8b0d2f4a6c");

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        public DbSet<User> User { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<DoctorCapacitySetting> DoctorCapacitySettings { get; set; }
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
        public DbSet<ChatParticipant> ChatParticipants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AppointmentHistory> AppointmentHistorie { get; set; }
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.UseEncryption(_encryptionProvider);

        }
    }
}