using Microsoft.Extensions.DependencyInjection;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.Implementations;

namespace SmartMedicalGuide.Services
{
    public static class ModuleServicesDependecies
    {
        public static IServiceCollection AddServicesDependecies(this IServiceCollection services)
        {
            services.AddTransient<IRoleServices, RoleServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IPatientServices, PatientServices>();
            services.AddTransient<IDoctorServices, DoctorServices>();
            services.AddTransient<ILabServices, LabServices>();
            services.AddTransient<IDoctorAppointmentServices, DoctorAppointmentServices>();
            services.AddTransient<IPaymentServices, PaymentServices>();
            services.AddTransient<IClinicServices, ClinicServices>();
            services.AddTransient<ILabAppointmentServices, LabAppointmentServices>();
            //services.AddTransient<IAuditLogServices, AuditLogServices>();
            //services.AddTransient<IChatServices, ChatServices>();
            //services.AddTransient<ILabServiceServices, LabServiceServices>();
            //services.AddTransient<IMedicalReportServices, MedicalReportServices>();
            //services.AddTransient<IMessageServices, MessageServices>();
            //services.AddTransient<INotificationServices, NotificationServices>();
            //services.AddTransient<IPrescriptionServices, PrescriptionServices>();
            //services.AddTransient<IReportServices, ReportServices>();
            //services.AddTransient<IReviewServices, ReviewServices>();
            services.AddTransient<ISystemSettingServices, SystemSettingServices>();
            //services.AddTransient<IVerificationRequestServices, VerificationRequestServices>();


            return services;
        }

    }
}
