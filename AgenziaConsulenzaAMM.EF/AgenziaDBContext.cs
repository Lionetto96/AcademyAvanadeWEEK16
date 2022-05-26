using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF
{
    public class AgenziaDBContext:DbContext
    {
        public DbSet<Dipendente> Dipendenti { get; set; }
        public DbSet<Cliente> Clienti { get; set; } 
        public DbSet<Commessa> Commesse { get; set; } 
        public DbSet<Attivita> Attivities { get; set; } 
        public DbSet<Timesheet> Timesheets { get; set; } 
        public DbSet<User> Users { get; set; }

        public AgenziaDBContext()
        {

        }
        public AgenziaDBContext(DbContextOptions<AgenziaDBContext> options)

            : base(options)

        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=tcp:avanadeamm-sql-srv.database.windows.net,1433;Initial Catalog=AgenziaConsulenzaAMM;Persist Security Info=False;User ID=mariadestefano;Password=AcademyAMM2022!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Commessa>(new CommessaConfiguration());
            modelBuilder.ApplyConfiguration<Dipendente>(new DipendenteConfiguration());
            modelBuilder.ApplyConfiguration<Timesheet>(new TimesheetConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Attivita>(new AttivitaConfiguration());

        }
    }
}
