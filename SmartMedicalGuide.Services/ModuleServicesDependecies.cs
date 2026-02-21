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
            services.AddTransient<IPaymentSevices, PaymentServices>();


            return services;
        }

    }
}
