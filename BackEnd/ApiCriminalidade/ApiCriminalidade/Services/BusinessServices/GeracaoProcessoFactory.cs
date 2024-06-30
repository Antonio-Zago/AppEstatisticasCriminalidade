using ApiCriminalidade.Models;
using ApiCriminalidade.Services.Interfaces;
using WokerService.Services.Interfaces;

namespace ApiCriminalidade.Services.BusinessServices
{
    public class GeracaoProcessoFactory : ProcessoFactory
    {
        private readonly IGeracaoIndiceCriminalidade _geracaoIndiceCriminalidade;
        public GeracaoProcessoFactory(IGeracaoIndiceCriminalidade geracaoIndiceCriminalidade) 
        {
            _geracaoIndiceCriminalidade = geracaoIndiceCriminalidade;
        }


        public override IProcessoComponent CriarProcesso(TipoProcesso tipo)
        {

            if (tipo == TipoProcesso.GeracaoIndicesCriminalidade)
            {
                return _geracaoIndiceCriminalidade.Create();
            }
            return null; 
        }
    }
}
