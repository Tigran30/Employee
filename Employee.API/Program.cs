using Employee.API.Middlewares;
using Employee.Core.Infrastructure.Interfaces;
using Employee.Core.Infrastructure.Services;
using Employee.Database;
using Employee.Repository;
using Employee.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionStrings:DbConnection"];
    if (connectionString.Contains("%CONTENTROOTPATH%"))
    {
        connectionString = connectionString.Replace("%CONTENTROOTPATH%", Directory.GetCurrentDirectory());
    }
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
