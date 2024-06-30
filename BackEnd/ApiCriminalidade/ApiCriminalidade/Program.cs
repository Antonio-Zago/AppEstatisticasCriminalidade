using ApiCriminalidade.Context;
using ApiCriminalidade.Helpers;
using ApiCriminalidade.Mappers;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services;
using ApiCriminalidade.Services.BusinessServices;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text.Json.Serialization;
using WokerService;
using WokerService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



//Services
builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();
builder.Services.AddScoped<IAssaltoService, AssaltoService>();
builder.Services.AddScoped<ITipoArmaService, TipoArmaService>();
builder.Services.AddScoped<IRouboService, RouboService>();
builder.Services.AddScoped<IIndOcorrenciaService, IndOcorrenciaService>();
builder.Services.AddScoped<IProcessoService, ProcessoService>();
builder.Services.AddScoped<IIndAssaltoService, IndAssaltoService>();
builder.Services.AddScoped<IZonaService, ZonaService>();


//Repositorys
builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
builder.Services.AddScoped<IAssaltoRepository, AssaltoRepository>();
builder.Services.AddScoped<ITipoArmaRepository, TipoArmaRepository>();
builder.Services.AddScoped<IRouboRepository, RouboRepository>();
builder.Services.AddScoped<ITipoBemRepository, TipoBemRepository>();
builder.Services.AddScoped<IIndOcorrenciaRepository, IndOcorrenciaRepository>();
builder.Services.AddScoped<IProcessoRepository,ProcessoRepository>();
builder.Services.AddScoped<IIndAssaltoRepository, IndAssaltoRepository>();
builder.Services.AddScoped<IZonaRepository, ZonaRepository>();

//Mappers
builder.Services.AddScoped<IOcorrenciaMapper, OcorrenciaMapper>();
builder.Services.AddScoped<IAssaltoMapper, AssaltoMapper>();
builder.Services.AddScoped<ITipoArmaMapper, TipoArmaMapper>();
builder.Services.AddScoped<IRouboMapper, RouboMapper>();
builder.Services.AddScoped<IIndOcorrenciaMapper, IndOcorrenciaMapper>();
builder.Services.AddScoped<IZonaMapper, ZonaMapper>();

builder.Services.AddTransient<IGeracaoIndiceCriminalidade, GeracaoIndicesCriminalidade>();
builder.Services.AddTransient<IQuery, Query>();
builder.Services.AddTransient<ProcessoFactory, GeracaoProcessoFactory>();

builder.Services.AddHostedService<Worker>();



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
