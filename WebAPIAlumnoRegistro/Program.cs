using Microsoft.EntityFrameworkCore;
using WebApiAlumnoRegistro.Authentication;
using WebAPIAlumnoRegistro.Models;
using WebAPIAlumnoRegistro.Models.Usuarios;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().
    LoadConfigurationFromAppSettings().
    GetCurrentClassLogger();

logger.Debug("Init main");

try
{
    var builder = WebApplication.CreateBuilder(args);


    //Registro de DBContext
    builder.Services.AddDbContext<DBContextRegistro>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlumnoRegistroConnection")));

    //Registro de Repositorios
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    //Nlog service
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();


    //Agregamos nuestro Api key
    builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();
    builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();


    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "Error en la aplicacion");
}
finally
{
   NLog.LogManager.Shutdown();
}
