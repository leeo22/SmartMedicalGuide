using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.API.Hubs;
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
builder.Services.AddSignalR();
builder.Services.AddDbContext<MedicalGuideDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
#endregion
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

#region Dependencies Injection
builder.Services.AddInfrastuctureDependecies()
                .AddServicesDependecies()
                .AddCoreDependecies()
                .AddServicesRegisteration(builder.Configuration);
#endregion
var app = builder.Build();
// ?????? ?? ???? ???? ??? ???????
var webRoot = app.Environment.WebRootPath;
if (string.IsNullOrEmpty(webRoot))
{
    webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    app.Environment.WebRootPath = webRoot;
}

// ????? ???????? ??? ?? ??? ?????? (?????? ??? ???????)
var uploadsFolder = Path.Combine(webRoot, "uploads", "attachments");
if (!Directory.Exists(uploadsFolder))
{
    Directory.CreateDirectory(uploadsFolder);
}

var profilesFolder = Path.Combine(webRoot, "uploads", "profiles");
if (!Directory.Exists(profilesFolder))
{
    Directory.CreateDirectory(profilesFolder);
}

var reportsFolder = Path.Combine(webRoot, "uploads", "medical-reports");
if (!Directory.Exists(reportsFolder))
{
    Directory.CreateDirectory(reportsFolder);
}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}


#region Map Hubs
app.MapHub<ChatHub>("/chatHub");
#endregion

#region Use CORS
app.UseCors("AllowAll");
#endregion


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
