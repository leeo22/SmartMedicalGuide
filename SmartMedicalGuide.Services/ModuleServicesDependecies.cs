using Microsoft.Extensions.DependencyInjection;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.Implementations;

namespace SmartMedicalGuide.Services
{
    public static class ModuleServicesDependecies
    {
        public static IServiceCollection AddServicesDependecies(this IServiceCollection services)
        {
            services.AddTransient<IPatientServices, PatientServices>();

            services.AddTransient<IDoctorServices, DoctorServices>();
            return services;
        }

    }
}
