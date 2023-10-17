using Microsoft.EntityFrameworkCore;
using WebApiAlumnoRegistro.Authentication;
using WebAPIAlumnoRegistro.Models;
using WebAPIAlumnoRegistro.Models.Usuarios;

var builder = WebApplication.CreateBuilder(args);


//Registro de DBContext
builder.Services.AddDbContext<DBContextRegistro>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AlumnoRegistroConnection")));

//Registro de Repositorios
//builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
//builder.Services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
