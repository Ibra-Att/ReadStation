using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReadStation.Context;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//Swagger Configs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Ur project name",
        Description = ""
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Logs
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string loggerPath = configuration.GetSection("LoggerPath").Value;

Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(loggerPath, rollingInterval: RollingInterval.Day).
                CreateLogger();



builder.Services.AddDbContext<ReadStationDbContext>(cnn => cnn.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnect")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Log.Information("Application Started"); app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
