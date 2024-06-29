using ApiCriminalidade.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Context
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

        public DbSet<IndAssalto> IndAssaltos { get; set; }

        public DbSet<Cidade> Cidades { get; set; }
        
    }
}
