using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Core;
using SmartMedicalGuide.Core.MiddleWare;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Infrastructure;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrustructure.Seeder;
using SmartMedicalGuide.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MedicalGuideDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


#region Dependencies Injection
builder.Services.AddInfrastuctureDependecies()
                .AddServicesDependecies()
                .AddCoreDependecies()
                .AddServicesRegisteration(builder.Configuration);
#endregion
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
