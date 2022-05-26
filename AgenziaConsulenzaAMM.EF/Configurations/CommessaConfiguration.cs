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
    public class CommessaConfiguration : IEntityTypeConfiguration<Commessa>
    {
        public void Configure(EntityTypeBuilder<Commessa> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Descrizione).IsRequired();
            builder.Property(c => c.DataInizio).IsRequired();
            builder.Property(c => c.DataFine).IsRequired();

            //Relazione con cliente
            builder.HasOne(x => x.Cliente).WithMany(t => t.Commesse).HasForeignKey(x => x.IDCliente);
            builder.HasData(new Commessa() { ID = 1, Nome = "Portale pubblico", Descrizione = "Descrizione del portale pubblico", DataInizio = new DateTime(2022 - 01 - 01), DataFine = new DateTime(2022 - 03 - 15) ,IDCliente=1},
                new Commessa() { ID = 2, Nome = "Applicazione Mobile", Descrizione = "Descrizione dell'applicazione mobile", DataInizio = new DateTime(2021 - 12 - 01), DataFine = new DateTime(2022 - 01 - 15) ,IDCliente=2},
                new Commessa() { ID = 3, Nome = "Portale privato", Descrizione = "Descrizione del portale privato", DataInizio = new DateTime(2022 - 02 - 01), DataFine = new DateTime(2022 - 03 - 15) ,IDCliente=3});


        }
    }
}
