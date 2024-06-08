﻿using ApiCriminalidade.Models;

namespace ApiCriminalidade.Repositorys.Interfaces
{
    public interface IRouboRepository
    {
        IEnumerable<Roubo> GetAll();

        Roubo GetById(int id);

        Roubo Post(Roubo entidade);

        Roubo Update(Roubo entidade);

        Roubo Delete(Roubo entidade);
    }
}
