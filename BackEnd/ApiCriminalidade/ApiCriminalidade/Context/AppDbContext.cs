﻿using ApiCriminalidade.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        public DbSet<Assalto> Assaltos { get; set; }

        public DbSet<TipoArma> TipoArmas { get; set; }

        public DbSet<Roubo> Roubos { get; set; }
    }
}
