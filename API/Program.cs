using System.Reflection;
using API.Extensions;
using API.Helpers;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()  
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger(); 

// builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
    

// Add services to the container.

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureCors();
builder.Services.ConfigureApiVersioning();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddAplicationServices();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true; // false by default
    options.ReturnHttpNotAcceptable = true; // Envia Mensaje de error
}).AddXmlSerializerFormatters();

builder.Services.AddValidationErrors();

//CONEXION A BASE DE DATOS MYSQL
// builder.Services.AddDbContext<BaseContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
// );

//CONEXION A BASE DE DATOS SQLITE
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TestConectionSQLite"))
);

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseIpRateLimiting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<BaseContext>();
        await context.Database.MigrateAsync();
        // await TiendaContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "An error occurred during migration");
    }
}

app.UseCors("CorsPolicy");

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
