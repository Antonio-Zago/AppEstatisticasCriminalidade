﻿using ApiCriminalidade.Services.Interfaces;
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


        public override IProcessoComponent CriarProcesso(int tipo)
        {

            if (tipo == 1)
            {
                return _geracaoIndiceCriminalidade.Create();
            }
            return null; 
        }
    }
}
