using DespesaViagem.Domain.Models.Core.Records;
using DespesaViagem.Domain.Models.Despesas;
using DespesaViagem.Domain.Models.Viagens;
using DespesaViagem.Infra.EntityConfiguration.Despesas;
using DespesaViagem.Infra.EntityConfiguration.RecordsTypeConfiguration;
using DespesaViagem.Infra.EntityConfiguration.Viagens;
using Microsoft.EntityFrameworkCore;

namespace DespesaViagem.Infra.Database
{
    public class DespesaViagemContext : DbContext
    {
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        //public DbSet<DespesaDeslocamento> DespesasDeslocamentos { get; set; }        
        public DbSet<DespesaHospedagem> DespesasHospedagens { get; set; }
        //public DbSet<DespesaPassagem> DespesasPassagens { get; set; }
        //public DbSet<DespesaRefeicao> DespesasRefeicoes { get; set; }

        //public DbSet<Endereco> Enderecos { get; set; }

        public DespesaViagemContext(DbContextOptions<DespesaViagemContext> options) : base(options) {}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Despesa>().HasKey(k => k.Id);

            modelBuilder.Entity<DespesaHospedagem>()
                        .HasBaseType<Despesa>();
           

            //modelBuilder.ApplyConfiguration(new DespesaEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new AgendamentoEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new EnderecoEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new EstabelecimentoEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new FuncionarioEntityTypeConfiguration());            
            //modelBuilder.ApplyConfiguration(new VeiculoEntityTypeConfiguration());

            //modelBuilder.ApplyConfiguration(new DespesaDeslocamentoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DespesaHospedagemEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new DespesaPassagemEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new DespesaRefeicaoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ViagemEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }        
    }
}
