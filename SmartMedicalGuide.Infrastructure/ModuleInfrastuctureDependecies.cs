using Microsoft.Extensions.DependencyInjection;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using SmartMedicalGuide.Infrastructure.Reposistories;

namespace SmartMedicalGuide.Infrastructure
{
    public static class ModuleInfrastuctureDependecies
    {
        public static IServiceCollection AddInfrastuctureDependecies(this IServiceCollection services)
        {
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ILabRepository, LabRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorAppointmentRepository, DoctorAppointmentRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IClinicRepository, ClinicRepository>();
            services.AddTransient<ILabAppointmentRepository, LabAppointmentRepository>();
            //services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IAuditLogRepository, AuditLogRepository>();
            //services.AddTransient<ILabServiceRepository, LabServiceRepository>();
            //services.AddTransient<IMedicalReportRepository, MedicalReportRepository>();
            //services.AddTransient<IMessageRepository, MessageRepository>();
            //services.AddTransient<INotificationRepository, NotificationRepository>();
            //services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            //services.AddTransient<IReportRepository, ReportRepository>();
            //services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<ISystemSettingRepository, SystemSettingRepository>();
            //services.AddTransient<IVerificationRequestRepository, VerificationRequestRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IDapperRepositoryAsync, DapperRepositoryAsync>();
            return services;
        }
    }
}
