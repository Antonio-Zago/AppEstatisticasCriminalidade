using ApiCriminalidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WokerService.Services.Interfaces
{
    public interface IProcessoComponent
    {
        public void Run();

        IProcessoComponent DefinirComponenteProcesso();
    }
}
