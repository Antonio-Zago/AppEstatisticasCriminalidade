

using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.BusinessServices
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
