using ApiCriminalidade.Context;
using ApiCriminalidade.Mappers;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Services
builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();
builder.Services.AddScoped<IAssaltoService, AssaltoService>();
builder.Services.AddScoped<ITipoArmaService, TipoArmaService>();
builder.Services.AddScoped<IRouboService, RouboService>();

//Repositorys
builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
builder.Services.AddScoped<IAssaltoRepository, AssaltoRepository>();
builder.Services.AddScoped<ITipoArmaRepository, TipoArmaRepository>();
builder.Services.AddScoped<IRouboRepository, RouboRepository>();
builder.Services.AddScoped<ITipoBemRepository, TipoBemRepository>();

//Mappers
builder.Services.AddScoped<IOcorrenciaMapper, OcorrenciaMapper>();
builder.Services.AddScoped<IAssaltoMapper, AssaltoMapper>();
builder.Services.AddScoped<ITipoArmaMapper, TipoArmaMapper>();
builder.Services.AddScoped<IRouboMapper, RouboMapper>();


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
