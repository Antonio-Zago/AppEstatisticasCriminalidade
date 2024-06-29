﻿namespace ApiCriminalidade.Models
{
    public class Zona
    {
        public int Id { get; set; }

        public decimal LatitudeCentral { get; set; }

        public decimal LongitudeCentral { get; set; }

        public decimal Raio { get; set; }

        public decimal Area { get; set; }

        public bool Ativo { get; set; }

        public int CidadeId { get; set; }

        public Cidade Cidade { get; set; }
    }
}
