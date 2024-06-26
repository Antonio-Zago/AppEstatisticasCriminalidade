﻿namespace ApiCriminalidade.Models
{
    public class Roubo
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }

        public Ocorrencia? Ocorrencia { get; set; }

        public IEnumerable<RouboTipoBem> RoubosTipoBens { get; set; }
    }
}
