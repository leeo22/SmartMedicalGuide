using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;


namespace SmartMedicalGuide.Infrastructure.Context
{
    public class MedicalGuideDbContext : DbContext
    {
        public MedicalGuideDbContext(DbContextOptions<MedicalGuideDbContext> options)
            : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SymptomAnalysis> SymptomAnalyses { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }


}
