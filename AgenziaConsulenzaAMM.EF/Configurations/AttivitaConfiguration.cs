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
    public class AttivitaConfiguration : IEntityTypeConfiguration<Attivita>
    {
        public void Configure(EntityTypeBuilder<Attivita> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a=>a.Nome)
                .IsRequired();           
            builder.Property(a => a.OreAllocate)
                .IsRequired();
            builder.Property(a=>a.CostoSingolaOra)
                .IsRequired();

            //navigationProperty
            builder.HasOne(c => c.Commessa).WithMany(a => a.Attivities).HasForeignKey(f => f.IdCommessa);
            builder.HasOne(d => d.Dipendente).WithMany(a => a.Attivita).HasForeignKey(f => f.IdDipendente);

            builder.HasData(new Attivita
            {
                Id = "A1",
                Nome ="sviluppo frontend ",
                OreAllocate = 4,
                CostoSingolaOra = 8,
                IdCommessa =1,
                IdDipendente="dip3"


            });
            builder.HasData(new Attivita
            {
                Id = "A2",
                Nome = "sviluppo frontend ",
                OreAllocate = 6,
                CostoSingolaOra = 9,
                IdCommessa = 2,
                IdDipendente = "dip2"


            });



        }
    }
}
