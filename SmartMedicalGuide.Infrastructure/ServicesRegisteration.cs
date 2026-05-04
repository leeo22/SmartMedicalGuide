using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Data.Helpers;
using SmartMedicalGuide.Infrastructure.Context;
using System.Text;



namespace SmartMedicalGuide.Infrastructure
{
    public static class ServicesRegisteration
    {
        public static IServiceCollection AddServicesRegisteration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<User, Role>(option =>
            {
                //Password Settings
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;
                // Lockout Settings
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;
                // User Settings
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<MedicalGuideDbContext>().AddDefaultTokenProviders();
            //JWT Authentication
            var jwtSettings = new JwtSettings();
            //var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            //configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(x =>
          {
              x.RequireHttpsMetadata = false;
              x.SaveToken = true;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = jwtSettings.ValidateIssuer,
                  ValidIssuers = new[] { jwtSettings.Issuer },
                  ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                  ValidAudience = jwtSettings.Audience,
                  ValidateAudience = jwtSettings.ValidateAudience,
                  ValidateLifetime = jwtSettings.ValidateLifeTime,
              };
          });
            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BedoonSarf Project", Version = "v1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
           });
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("CreateUser", policy =>
                {
                    policy.RequireClaim("Create User", "True");
                });
                option.AddPolicy("DeleteUser", policy =>
                {
                    policy.RequireClaim("Delete User", "True");
                });
                option.AddPolicy("EditUser", policy =>
                {
                    policy.RequireClaim("Edit User", "True");
                });
            });

            return services;
        }
    }
}
