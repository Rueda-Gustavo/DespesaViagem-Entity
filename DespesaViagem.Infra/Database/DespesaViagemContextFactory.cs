using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DespesaViagem.Infra.Database
{
    public class DespesaViagemContextFactory : IDesignTimeDbContextFactory<DespesaViagemContext>
    {
        public DespesaViagemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DespesaViagemContext>();
            optionsBuilder.UseSqlServer("ConnectionString");
            optionsBuilder.EnableSensitiveDataLogging();

            return new DespesaViagemContext(optionsBuilder.Options);
        }
    }
}
