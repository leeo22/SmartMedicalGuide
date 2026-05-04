using Microsoft.Extensions.DependencyInjection;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using SmartMedicalGuide.Infrastructure.Reposistories;
using SmartMedicalGuide.Infrastructure.Repositories;

namespace SmartMedicalGuide.Infrastructure
{
    public static class ModuleInfrastuctureDependecies
    {
        public static IServiceCollection AddInfrastuctureDependecies(this IServiceCollection services)
        {
            //services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ILabRepository, LabRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorAppointmentRepository, DoctorAppointmentRepository>();
            services.AddScoped<IChatParticipantRepository, ChatParticipantRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IClinicRepository, ClinicRepository>();
            services.AddTransient<ILabAppointmentRepository, LabAppointmentRepository>();
            services.AddTransient<IAppointmentHistoryRepository, AppointmentHistoryRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IDoctorScheduleRepository, DoctorScheduleRepository>();
            services.AddTransient<IAuditLogRepository, AuditLogRepository>();
            services.AddTransient<IPrescriptionItemRepository, PrescriptionItemRepository>();
            services.AddTransient<IAttachmentRepository, AttachmentRepository>();
            services.AddTransient<ISearchHistoryRepository, SearchHistoryRepository>();
            services.AddTransient<ILabServiceRepository, LabServiceRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserSessionRepository, UserSessionRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IMedicalReportRepository, MedicalReportRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IFavoriteRepository, FavoriteRepository>();
            services.AddTransient<ISpecializationRepository, SpecializationRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IDoctorCapacitySettingRepository, DoctorCapacitySettingRepository>();
            //services.AddTransient<ISystemSettingRepository, SystemSettingRepository>();
            services.AddTransient<IVerificationRequestRepository, VerificationRequestRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            //services.AddTransient<IDapperRepositoryAsync, DapperRepositoryAsync>();
            return services;
        }
    }
}
