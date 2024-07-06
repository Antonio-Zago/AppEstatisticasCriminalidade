using ApiCriminalidade.Models;
using ApiCriminalidade.Services.Interfaces;

namespace ApiCriminalidade.Services.BusinessServices
{
    public abstract class ProcessoFactory
    {
        public abstract IProcessoComponent CriarProcesso(TipoProcesso tipo);
    }
}
