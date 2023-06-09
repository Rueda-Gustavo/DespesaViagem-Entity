﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DespesaViagem.Infra.Database
{
    public class DespesaViagemContextFactory : IDesignTimeDbContextFactory<DespesaViagemContext>
    {
        public DespesaViagemContext CreateDbContext(string[] args)
        {            
            var optionsBuilder = new DbContextOptionsBuilder<DespesaViagemContext>();
            optionsBuilder.UseSqlServer("Data Source=GUSTAVO;Initial Catalog=DespesaViagem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //String de conexão para utilizar o docker
            //optionsBuilder.UseSqlServer("Data Source = localhost,1433; Database = DespesaViagem; Persist Security Info = True; Encrypt = False; User ID = sa; Password = teste@1234");
            optionsBuilder.EnableSensitiveDataLogging();

            return new DespesaViagemContext(optionsBuilder.Options);
        }
    }
}
