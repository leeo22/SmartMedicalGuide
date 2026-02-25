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

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
