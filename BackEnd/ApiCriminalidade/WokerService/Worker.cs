

using ApiCriminalidade.Models;
using ApiCriminalidade.Services;
using ApiCriminalidade.Services.Interfaces;
using WokerService.Services;
using WokerService.Services.Interfaces;

namespace WokerService
{
    public class Worker : BackgroundService
    {

        private readonly IProcessoService _processoService;

        public Worker(IProcessoService processoService)
        {
            _processoService = processoService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var processosAguardando = _processoService.GetAll().Where(p => p.StatusAtual == ApiCriminalidade.Models.StatusProcesso.Aguardando);


                foreach (var processo in processosAguardando) 
                {
                    IProcessoComponent processoComponent = DefinirComponenteProcesso(processo.Tipo);
                    processoComponent.Run();
                }


                await Task.Delay(5000, stoppingToken);
            }
        }

        private IProcessoComponent DefinirComponenteProcesso(TipoProcesso tipo)
        {
            if (tipo == TipoProcesso.GeracaoIndicesCriminalidade)
            {
                return new GeracaoIndicesCriminalidade();
            }

            return null;
        }
    }
}
