
using ApiCriminalidade.Application.BusinessServices;
using ApiCriminalidade.Application.Helpers;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiCriminalidade.Application.Services
{
    public class Worker : BackgroundService
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly ILogger<Worker> _logger;

        private readonly ProcessoFactory _processoFactory;

        private readonly IQuery _query;

        public Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger, ProcessoFactory processoFactory, IQuery query)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _processoFactory = processoFactory;
            _query = query;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    var processoService = scope
                    .ServiceProvider
                    .GetRequiredService<IProcessoService>();

                    var processosAguardando = processoService.GetAll().Where(p => p.StatusAtual == StatusProcesso.Aguardando);


                    foreach (var processo in processosAguardando)
                    {
                        IProcessoComponent processoComponent = _processoFactory.CriarProcesso(processo.Tipo);
                        processoComponent.Run();

                        MudarStatusProcesso(processo.Id);
                    }
                }   

                await Task.Delay(5000, stoppingToken);
            }
        }

        private void MudarStatusProcesso(int id)
        {
            var sql = @$"UPDATE PROCESSOS
                        SET STATUSATUAL = @STATUS,
                        DATAEXECUCAO = @DATAATUAL
                        WHERE ID = @ID";

            _query.ExecuteNonQuery(sql, [new SqlParameter("STATUS",StatusProcesso.Finalizado),
                                       new SqlParameter("ID",id),
                                       new SqlParameter("DATAATUAL",DateTime.Now)]);
        }

       
    }
}
