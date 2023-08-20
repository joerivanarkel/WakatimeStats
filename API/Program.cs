using System.Reflection;
using Business.Services;
using Business.Services.Interface;
using DataAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API v1", Version = "v1" });

    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

// Services
builder.Services.AddScoped<IHeartbeatService, HeartbeatService>();

// Repositories
builder.Services.AddScoped<IHeartbeatRepository, HeartbeatRepository>();

// Database
builder.Services.AddDbContext<DatabaseContext>();



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
}

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();