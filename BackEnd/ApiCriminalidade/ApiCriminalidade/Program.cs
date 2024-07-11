using ApiCriminalidade.Context;
using ApiCriminalidade.Helpers;
using ApiCriminalidade.Mappers;
using ApiCriminalidade.Mappers.Interface;
using ApiCriminalidade.Repositorys;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services;
using ApiCriminalidade.Services.BusinessServices;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;
using WokerService;


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

var secretKey = builder.Configuration["JWT:SecretKey"]
                   ?? throw new ArgumentException("Invalid secret key!!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ADMINEXCLUSIVO", policy => policy.RequireRole("ADMIN"));
    options.AddPolicy("USUARIOGERAL", policy => policy.RequireAssertion(context => 
                                        context.User.IsInRole("ADMIN") || context.User.IsInRole("USER")) );
});

builder.Services.AddExceptionHandler<AppExceptionHandler>();

//Services
builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();
builder.Services.AddScoped<IAssaltoService, AssaltoService>();
builder.Services.AddScoped<ITipoArmaService, TipoArmaService>();
builder.Services.AddScoped<IRouboService, RouboService>();
builder.Services.AddScoped<IIndOcorrenciaService, IndOcorrenciaService>();
builder.Services.AddScoped<IProcessoService, ProcessoService>();
builder.Services.AddScoped<IIndAssaltoService, IndAssaltoService>();
builder.Services.AddScoped<IZonaService, ZonaService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();


//Repositorys
builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
builder.Services.AddScoped<IAssaltoRepository, AssaltoRepository>();
builder.Services.AddScoped<ITipoArmaRepository, TipoArmaRepository>();
builder.Services.AddScoped<IRouboRepository, RouboRepository>();
builder.Services.AddScoped<ITipoBemRepository, TipoBemRepository>();
builder.Services.AddScoped<IIndOcorrenciaRepository, IndOcorrenciaRepository>();
builder.Services.AddScoped<IProcessoRepository,ProcessoRepository>();
builder.Services.AddScoped<IIndRouboRepository, IndRouboRepository>();
builder.Services.AddScoped<IZonaRepository, ZonaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPermissaoRepository, PermissaoRepository>();


//Mappers
builder.Services.AddScoped<IOcorrenciaMapper, OcorrenciaMapper>();
builder.Services.AddScoped<IAssaltoMapper, AssaltoMapper>();
builder.Services.AddScoped<ITipoArmaMapper, TipoArmaMapper>();
builder.Services.AddScoped<IRouboMapper, RouboMapper>();
builder.Services.AddScoped<IIndOcorrenciaMapper, IndOcorrenciaMapper>();
builder.Services.AddScoped<IZonaMapper, ZonaMapper>();
builder.Services.AddScoped<IUsuarioMapper, UsuarioMapper>();
builder.Services.AddScoped<IPermissaoMapper, PermissaoMapper>();

builder.Services.AddTransient<GeracaoIndicesCriminalidade>();
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

app.UseExceptionHandler( _ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
