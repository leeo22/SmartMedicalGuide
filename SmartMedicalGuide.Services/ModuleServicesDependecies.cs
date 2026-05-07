using Microsoft.Extensions.DependencyInjection;
using SmartMedicalGuide.Service.Abstracts;
using SmartMedicalGuide.Service.Implementations;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.AuthServices.Implementations;
using SmartMedicalGuide.Services.AuthServices.Interfaces;
using SmartMedicalGuide.Services.Implementations;

namespace SmartMedicalGuide.Services
{
    public static class ModuleServicesDependecies
    {
        public static IServiceCollection AddServicesDependecies(this IServiceCollection services)
        {
            //services.AddTransient<IRoleServices, RoleServices>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IUserSessionServices, UserSessionServices>();
            services.AddTransient<IPatientServices, PatientServices>();
            services.AddTransient<IAppointmentHistoryServices, AppointmentHistoryServices>();
            services.AddTransient<IDoctorServices, DoctorServices>();
            services.AddTransient<IAttachmentServices, AttachmentServices>();
            services.AddTransient<IDoctorScheduleServices, DoctorScheduleServices>();
            services.AddTransient<ILabServices, LabServices>();
            services.AddTransient<IWalletServices, WalletServices>();
            services.AddTransient<IDoctorAppointmentServices, DoctorAppointmentServices>();
            services.AddTransient<IPaymentServices, PaymentServices>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddTransient<IClinicServices, ClinicServices>();
            services.AddTransient<ILabAppointmentServices, LabAppointmentServices>();
            services.AddTransient<ISpecializationServices, SpecializationServices>();
            services.AddTransient<IFavoriteServices, FavoriteServices>();
            services.AddTransient<IAppointmentHistoryServices, AppointmentHistoryServices>();
            services.AddTransient<ISearchHistoryServices, SearchHistoryServices>();
            services.AddTransient<IAuditLogServices, AuditLogServices>();
            services.AddTransient<ITransactionServices, TransactionServices>();
            services.AddTransient<IChatServices, ChatServices>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IChatParticipantServices, ChatParticipantServices>();
            services.AddTransient<ILabServiceServices, LabServiceServices>();
            services.AddTransient<IMedicalReportServices, MedicalReportServices>();
            services.AddTransient<IMessageServices, MessageServices>();
            services.AddTransient<INotificationServices, NotificationServices>();
            services.AddTransient<IPrescriptionServices, PrescriptionServices>();
            services.AddTransient<IPrescriptionItemServices, PrescriptionItemServices>();
            services.AddTransient<IReportServices, ReportServices>();
            services.AddTransient<IReviewServices, ReviewServices>();
            services.AddTransient<IEmailsService, EmailsService>();
            services.AddTransient<IDoctorCapacitySettingServices, DoctorCapacitySettingServices>();
            //services.AddTransient<ISystemSettingServices, SystemSettingServices>();
            services.AddTransient<IVerificationRequestServices, VerificationRequestServices>();


            return services;
        }

    }
}
