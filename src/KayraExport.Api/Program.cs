using FluentValidation;
using KayraExport.Application.Interfaces;
using KayraExport.Application.Services;
using KayraExport.Api.Middleware; 
using KayraExport.Infrastructure.Persistence;
using KayraExport.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using KayraExport.Infrastructure.Options;
using KayraExport.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(DatabaseSettings.SectionName));
    
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;

    //If there is an environment variable, use it; otherwise, use the value in appsettings.json.
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION") ?? dbSettings.DefaultConnection;

    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // 1. Api XML
    var apiAssembly = Assembly.GetExecutingAssembly();
    var xmlApiFilename = $"{apiAssembly.GetName().Name}.xml";
    var xmlApiPath = Path.Combine(AppContext.BaseDirectory, xmlApiFilename);
    options.IncludeXmlComments(xmlApiPath);

    // 2. Application XML
    var appAssembly = typeof(ProductDto).Assembly; 
    var xmlAppFilename = $"{appAssembly.GetName().Name}.xml";
    var xmlAppPath = Path.Combine(AppContext.BaseDirectory, xmlAppFilename);
    options.IncludeXmlComments(xmlAppPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
