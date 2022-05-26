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
    public class DipendenteConfiguration : IEntityTypeConfiguration<Dipendente>
    {
        public void Configure(EntityTypeBuilder<Dipendente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Cognome).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.DataNascita).IsRequired();
            builder.Property(x=>x.DataAssunzione).IsRequired();
            builder.Property(x=>x.Mansione).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.CostoOrarioAzienda).IsRequired();
            //navigation Property
            builder.HasMany(x => x.Attivita).WithOne(x=>x.Dipendente);
            builder.HasMany(x => x.Timesheets).WithOne(x => x.Dipendente);

            builder.HasData(new Dipendente
            {
                Id = "dip1",
                Nome = "Alessia",
                Cognome = "Lionetto",
                DataNascita = new DateTime(1996, 08, 19),
                DataAssunzione = new DateTime(2021, 11, 15),
                Email = "ale.lio@gmail.com",
                Mansione = MansioneEnum.Consultant,
                CostoOrarioAzienda = 8.5m
            });
            builder.HasData(new Dipendente
            {
                Id = "dip2",
                Nome = "Maria",
                Cognome = "De Stefano",
                DataNascita = new DateTime(1991, 04, 12),
                DataAssunzione = new DateTime(2021, 11, 15),
                Email = "mari.ds12@gmail.com",
                Mansione = MansioneEnum.Analyst,
                CostoOrarioAzienda = 9m
            });
            builder.HasData(new Dipendente
            {
                Id = "dip3",
                Nome = "Martina",
                Cognome = "Tiso",
                DataNascita = new DateTime(1994, 07, 16),
                DataAssunzione = new DateTime(2021, 11, 01),
                Email = "marti.tiso@gmail.com",
                Mansione = MansioneEnum.SeniorAnalyst,
                CostoOrarioAzienda = 9.5m
            });
        }
    }
}
