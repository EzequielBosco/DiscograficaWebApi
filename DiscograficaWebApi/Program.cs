using DiscograficaWebApi.DAL;
using DiscograficaWebApi.DAL.Data;
using DiscograficaWebApi.DAL.Repository;
using DiscograficaWebApi.DAL.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//------------------Repository--------------
builder.Services.AddScoped<IDiscograficaRepository, DiscograficaRepository>();
builder.Services.AddScoped<IArtistaRepository, ArtistaRepository>();
builder.Services.AddScoped<IDiscoRepository, DiscoRepository>();
builder.Services.AddScoped<ICancionRepository, CancionRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//------------------UnitOfWork--------------
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DataContext>(),
    x.GetRequiredService<IDiscograficaRepository>(),
    x.GetRequiredService<IArtistaRepository>(),
    x.GetRequiredService<IDiscoRepository>(),
    x.GetRequiredService<ICancionRepository>(),
    x.GetRequiredService<IUsuarioRepository>()));

//------------------DbContext---------------
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));

//------------------Serilog-----------------
var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(conf).CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
