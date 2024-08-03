

using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.BusinessServices
{
    public class GeracaoProcessoFactory : ProcessoFactory
    {
        private readonly GeracaoIndicesCriminalidade _geracaoIndiceCriminalidade;
        private readonly GeracaoIndiceMedio _geracaoIndiceMedio;
        public GeracaoProcessoFactory(GeracaoIndicesCriminalidade geracaoIndiceCriminalidade, GeracaoIndiceMedio geracaoIndiceMedio)
        {
            _geracaoIndiceCriminalidade = geracaoIndiceCriminalidade;
            _geracaoIndiceMedio = geracaoIndiceMedio;
        }


        public override IProcessoComponent CriarProcesso(TipoProcesso tipo)
        {

            if (tipo == TipoProcesso.GeracaoIndicesCriminalidade)
            {
                return _geracaoIndiceCriminalidade.Create();
            }
            else if (tipo == TipoProcesso.GeracaoIndiceMedio)
            {
                return _geracaoIndiceMedio.Create();
            }
            return null; 
        }
    }
}
