using ApiCriminalidade.Services.Interfaces;
using ApiCriminalidade.Services;
using WokerService;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Context;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IProcessoService, ProcessoService>();
builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
