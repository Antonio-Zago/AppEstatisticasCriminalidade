﻿using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Mappings.Interface
{
    public interface ITipoBemMapper
    {
        TipoBemDto ToDto(TipoBem Entidade);

        TipoBem ToEntidade(TipoBemForm form);
    }
}