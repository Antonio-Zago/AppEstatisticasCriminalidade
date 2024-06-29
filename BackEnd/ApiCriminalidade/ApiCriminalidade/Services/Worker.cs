

using ApiCriminalidade.Context;
using ApiCriminalidade.Helpers;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using ApiCriminalidade.Services;
using ApiCriminalidade.Services.BusinessServices;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using WokerService.Services;
using WokerService.Services.Interfaces;

namespace WokerService
{
    public class Worker : BackgroundService
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly ILogger<Worker> _logger;

        private readonly IProcessoComponent _processoComponent;

        private readonly IQuery _query;

        public Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger, IProcessoComponent processoComponent, IQuery query)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _processoComponent = processoComponent;
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
                         IProcessoComponent processoComponent = _processoComponent.DefinirComponenteProcesso();
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
                        SET STATUSATUAL = @STATUS
                        WHERE ID = @ID";

            _query.ExecuteInsert(sql, [new SqlParameter("STATUS",StatusProcesso.Finalizado),
                                       new SqlParameter("ID",id)]);
        }

       
    }
}
