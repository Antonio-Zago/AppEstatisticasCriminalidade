﻿using ApiCriminalidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssaltoTipoBem>()
                .HasKey(x => new { x.AssaltoId, x.TipoBemId });

            modelBuilder.Entity<RouboTipoBem>()
                .HasKey(x => new { x.RouboId, x.TipoBemId });

            modelBuilder.Entity<UsuarioPermissao>()
                .HasKey(x => new { x.UsuarioId, x.PermissaoId });

            modelBuilder.Entity<UsuarioPermissao>()
                .HasKey(x => new { x.UsuarioId, x.PermissaoId });
        }

        protected override void ConfigureConventions(
    ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(15, 6);
        }


        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        public DbSet<Assalto> Assaltos { get; set; }

        public DbSet<TipoArma> TipoArmas { get; set; }

        public DbSet<Roubo> Roubos { get; set; }

        public DbSet<TipoBem> TipoBens { get; set; }

        public DbSet<AssaltoTipoBem> AssaltosTipobens { get; set; }

        public DbSet<RouboTipoBem> RoubosTipobens { get; set; }

        public DbSet<IndOcorrencia> IndOcorrencias { get; set; }

        public DbSet<Processo> Processos { get; set; }

        public DbSet<Zona> Zonas { get; set; }

        public DbSet<IndRoubo> IndRoubos { get; set; }

        public DbSet<IndFurto> IndFurtos { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Permissao> Permissoes { get; set; }

        public DbSet<UsuarioPermissao> UsuariosPermissoes { get; set; }


        public DbSet<IndMedio> IndMedios { get; set; }
    }
}
