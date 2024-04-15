using DataAccess.Repository;
using DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SampleDemoWithoutIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'SampleDemoWithoutIdentityContextConnection' not found.");

builder.Services.AddControllers();
builder.Services.AddSingleton<IEmployeeInterface>(serviceProvider =>
{
    return new EmployeeService(connectionString); // Pass the dependency to the constructor
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
