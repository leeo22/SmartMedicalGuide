using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Core;
using SmartMedicalGuide.Core.MiddleWare;
using SmartMedicalGuide.Infrastructure;
using SmartMedicalGuide.Infrastructure.Context;
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
                .AddCoreDependecies();
#endregion
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
