﻿// <auto-generated />
using System;
using AgenziaConsulenzaAMM.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgenziaConsulenzaAMM.EF.Migrations
{
    [DbContext(typeof(AgenziaDBContext))]
    partial class AgenziaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Attivita", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CostoSingolaOra")
                        .HasColumnType("float");

                    b.Property<int>("IdCommessa")
                        .HasColumnType("int");

                    b.Property<string>("IdDipendente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OreAllocate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCommessa");

                    b.HasIndex("IdDipendente");

                    b.ToTable("Attivities");

                    b.HasData(
                        new
                        {
                            Id = "A1",
                            CostoSingolaOra = 8.0,
                            IdCommessa = 1,
                            IdDipendente = "dip3",
                            Nome = "sviluppo frontend ",
                            OreAllocate = 4
                        },
                        new
                        {
                            Id = "A2",
                            CostoSingolaOra = 9.0,
                            IdCommessa = 2,
                            IdDipendente = "dip2",
                            Nome = "sviluppo frontend ",
                            OreAllocate = 6
                        });
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dimensione")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Clienti");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Citta = "Roma",
                            Dimensione = 1,
                            Nome = "Vodafone",
                            Provincia = "RM",
                            Regione = "Lazio"
                        },
                        new
                        {
                            ID = 2,
                            Citta = "Milano",
                            Dimensione = 2,
                            Nome = "Bcc",
                            Provincia = "MI",
                            Regione = "Lombardia"
                        },
                        new
                        {
                            ID = 3,
                            Citta = "Roma",
                            Dimensione = 3,
                            Nome = "Telecom",
                            Provincia = "RM",
                            Regione = "Lazio"
                        });
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Commessa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFine")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInizio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDCliente");

                    b.ToTable("Commesse");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DataFine = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004),
                            DataInizio = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2020),
                            Descrizione = "Descrizione del portale pubblico",
                            IDCliente = 1,
                            Nome = "Portale pubblico"
                        },
                        new
                        {
                            ID = 2,
                            DataFine = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006),
                            DataInizio = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2008),
                            Descrizione = "Descrizione dell'applicazione mobile",
                            IDCliente = 2,
                            Nome = "Applicazione Mobile"
                        },
                        new
                        {
                            ID = 3,
                            DataFine = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004),
                            DataInizio = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019),
                            Descrizione = "Descrizione del portale privato",
                            IDCliente = 3,
                            Nome = "Portale privato"
                        });
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Dipendente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("CostoOrarioAzienda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataAssunzione")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Mansione")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Dipendenti");

                    b.HasData(
                        new
                        {
                            Id = "dip1",
                            Cognome = "Lionetto",
                            CostoOrarioAzienda = 8.5m,
                            DataAssunzione = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascita = new DateTime(1996, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ale.lio@gmail.com",
                            Mansione = 2,
                            Nome = "Alessia"
                        },
                        new
                        {
                            Id = "dip2",
                            Cognome = "De Stefano",
                            CostoOrarioAzienda = 9m,
                            DataAssunzione = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascita = new DateTime(1991, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mari.ds12@gmail.com",
                            Mansione = 4,
                            Nome = "Maria"
                        },
                        new
                        {
                            Id = "dip3",
                            Cognome = "Tiso",
                            CostoOrarioAzienda = 9.5m,
                            DataAssunzione = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascita = new DateTime(1994, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marti.tiso@gmail.com",
                            Mansione = 3,
                            Nome = "Martina"
                        });
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Timesheet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataTimesheet")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdAttivita")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDipendente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("NumeroOre")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdAttivita");

                    b.HasIndex("IdDipendente");

                    b.ToTable("Timesheets");

                    b.HasData(
                        new
                        {
                            Id = "TS1",
                            DataTimesheet = new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAttivita = "A1",
                            IdDipendente = "dip2",
                            NumeroOre = 25.0
                        });
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "Academy2022",
                            Role = 1,
                            Username = "martina.tiso"
                        },
                        new
                        {
                            Id = 2,
                            Password = "novembre2022",
                            Role = 1,
                            Username = "alessia.lionetto"
                        },
                        new
                        {
                            Id = 3,
                            Password = "forGirls2022",
                            Role = 1,
                            Username = "maria.de.stefano"
                        },
                        new
                        {
                            Id = 4,
                            Password = "Pippo123",
                            Role = 0,
                            Username = "diego.angelino"
                        });
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Attivita", b =>
                {
                    b.HasOne("AgenziaConsulenzaAMM.Core.Models.Commessa", "Commessa")
                        .WithMany("Attivities")
                        .HasForeignKey("IdCommessa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgenziaConsulenzaAMM.Core.Models.Dipendente", "Dipendente")
                        .WithMany("Attivita")
                        .HasForeignKey("IdDipendente");

                    b.Navigation("Commessa");

                    b.Navigation("Dipendente");
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Commessa", b =>
                {
                    b.HasOne("AgenziaConsulenzaAMM.Core.Models.Cliente", "Cliente")
                        .WithMany("Commesse")
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Timesheet", b =>
                {
                    b.HasOne("AgenziaConsulenzaAMM.Core.Models.Attivita", "Attivita")
                        .WithMany("Timesheets")
                        .HasForeignKey("IdAttivita");

                    b.HasOne("AgenziaConsulenzaAMM.Core.Models.Dipendente", "Dipendente")
                        .WithMany("Timesheets")
                        .HasForeignKey("IdDipendente");

                    b.Navigation("Attivita");

                    b.Navigation("Dipendente");
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Attivita", b =>
                {
                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Cliente", b =>
                {
                    b.Navigation("Commesse");
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Commessa", b =>
                {
                    b.Navigation("Attivities");
                });

            modelBuilder.Entity("AgenziaConsulenzaAMM.Core.Models.Dipendente", b =>
                {
                    b.Navigation("Attivita");

                    b.Navigation("Timesheets");
                });
#pragma warning restore 612, 618
        }
    }
}
