using SmartMedicalGuide.Core;
using SmartMedicalGuide.Core.MiddleWare;
using SmartMedicalGuide.Infrastructure;
using SmartMedicalGuide.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependencies Injection
builder.Services.AddInfrastuctureDependecies()
                .AddServicesDependecies()
                .AddCoreDependecies();
//.AddServicesRegisteration( );
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
