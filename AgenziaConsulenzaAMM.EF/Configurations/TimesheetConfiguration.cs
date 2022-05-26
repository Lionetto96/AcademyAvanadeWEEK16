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
    public class TimesheetConfiguration:IEntityTypeConfiguration<Timesheet>
    {
        public void Configure(EntityTypeBuilder<Timesheet> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeroOre)
                   .IsRequired();
            builder.Property(x => x.DataTimesheet);
            //navigation Property
            builder.HasOne(x=>x.Attivita).WithMany(t=>t.Timesheets).HasForeignKey(x=>x.IdAttivita);
            builder.HasOne(x => x.Dipendente).WithMany(d => d.Timesheets).HasForeignKey(x => x.IdDipendente);

            builder.HasData(new Timesheet()
            {
                Id = "TS1",
                NumeroOre = 25,
                DataTimesheet = new DateTime(2022, 08, 29),
                IdAttivita = "A1",
                IdDipendente = "dip2"
            });

        }
    }
}
