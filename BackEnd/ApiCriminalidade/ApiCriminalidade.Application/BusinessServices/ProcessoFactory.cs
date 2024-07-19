

using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.BusinessServices
{
    public abstract class ProcessoFactory
    {
        public abstract IProcessoComponent CriarProcesso(TipoProcesso tipo);
    }
}
