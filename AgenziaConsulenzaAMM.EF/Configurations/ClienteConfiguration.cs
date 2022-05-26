using AgenziaConsulenzaAMM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Citta).IsRequired();
            builder.Property(c => c.Regione).IsRequired();
            builder.Property(c => c.Provincia).IsRequired();
            builder.Property(c => c.Dimensione).IsRequired();

            builder.HasMany(x => x.Commesse).WithOne(t => t.Cliente);
            //relazione con Commessa

            builder.HasData(new Cliente() { ID = 1, Nome = "Vodafone", Citta = "Roma",Regione="Lazio",Provincia="RM",Dimensione=DimensioneEnum.Media },
                new Cliente() { ID = 2, Nome = "Bcc", Citta = "Milano" , Regione = "Lombardia", Provincia = "MI", Dimensione = DimensioneEnum.Grande},
                new Cliente() { ID = 3, Nome = "Telecom", Citta = "Roma", Regione = "Lazio", Provincia = "RM", Dimensione = DimensioneEnum.Enterprise});
        }
    }
}
