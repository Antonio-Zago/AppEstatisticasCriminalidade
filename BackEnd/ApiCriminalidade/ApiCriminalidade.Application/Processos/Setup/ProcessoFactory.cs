

using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;

namespace ApiCriminalidade.Application.Processos.Setup
{
    public abstract class ProcessoFactory
    {
        public abstract IProcessoComponent CriarProcesso(TipoProcesso tipo);
    }
}
