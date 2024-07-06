using ApiCriminalidade.Models;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services.BusinessServices
{
    public class GeracaoProcessoFactory : ProcessoFactory
    {
        private readonly GeracaoIndicesCriminalidade _geracaoIndiceCriminalidade;
        public GeracaoProcessoFactory(GeracaoIndicesCriminalidade geracaoIndiceCriminalidade) 
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
