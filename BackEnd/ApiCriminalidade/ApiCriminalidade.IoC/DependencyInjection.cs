using ApiCriminalidade.Application.BusinessServices;
using ApiCriminalidade.Application.Helpers;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Application.Mappings;
using ApiCriminalidade.Application.Mappings.Interface;
using ApiCriminalidade.Application.Services;
using ApiCriminalidade.Domain.Interfaces;
using ApiCriminalidade.Infraestructure.Context;
using ApiCriminalidade.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
           

            //Services
            services.AddScoped<IOcorrenciaService, OcorrenciaService>();
            services.AddScoped<IAssaltoService, AssaltoService>();
            services.AddScoped<ITipoArmaService, TipoArmaService>();
            services.AddScoped<IRouboService, RouboService>();
            services.AddScoped<IIndOcorrenciaService, IndOcorrenciaService>();
            services.AddScoped<IProcessoService, ProcessoService>();
            services.AddScoped<IIndAssaltoService, IndAssaltoService>();
            services.AddScoped<IZonaService, ZonaService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPermissaoService, PermissaoService>();


            //Repositorys
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
            services.AddScoped<IAssaltoRepository, AssaltoRepository>();
            services.AddScoped<ITipoArmaRepository, TipoArmaRepository>();
            services.AddScoped<IRouboRepository, RouboRepository>();
            services.AddScoped<ITipoBemRepository, TipoBemRepository>();
            services.AddScoped<IIndOcorrenciaRepository, IndOcorrenciaRepository>();
            services.AddScoped<IProcessoRepository, ProcessoRepository>();
            services.AddScoped<IIndRouboRepository, IndRouboRepository>();
            services.AddScoped<IZonaRepository, ZonaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();


            //Mappers
            services.AddScoped<IOcorrenciaMapper, OcorrenciaMapper>();
            services.AddScoped<IAssaltoMapper, AssaltoMapper>();
            services.AddScoped<ITipoArmaMapper, TipoArmaMapper>();
            services.AddScoped<IRouboMapper, RouboMapper>();
            services.AddScoped<IIndOcorrenciaMapper, IndOcorrenciaMapper>();
            services.AddScoped<IZonaMapper, ZonaMapper>();
            services.AddScoped<IUsuarioMapper, UsuarioMapper>();
            services.AddScoped<IPermissaoMapper, PermissaoMapper>();

            services.AddTransient<GeracaoIndicesCriminalidade>();
            services.AddTransient<IQuery, Query>();
            services.AddTransient<ProcessoFactory, GeracaoProcessoFactory>();

            services.AddHostedService<Worker>();

            return services;
        }
    }
}
