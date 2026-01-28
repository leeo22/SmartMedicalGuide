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
            services.AddTransient<IPatientRepository, PatientRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
