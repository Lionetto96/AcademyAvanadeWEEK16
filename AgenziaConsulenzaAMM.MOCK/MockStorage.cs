using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;

namespace AgenziaConsulenzaAMM.MOCK
{
    public class MockStorage
    {
        public IList<Cliente> Clienti { get; set; }
        public IList<Commessa> Commesse { get; set; }
        public IList<Timesheet> Timesheets { get; set; }
        public IList<Dipendente> dipendenti { get; set; }
        public IList<User> Users { get; set; }
        public IList<Attivita> Attivita { get; set; }
        

        
        

        public MockStorage()
        {

            #region Cliente
            //Inizializzo la lista dei clienti vuota
            Clienti = new List<Cliente>();

            //Adesso aggiungo 3 libri in memoria
            Clienti.Add(new Cliente
            {
                ID = 1,
                Nome = "Vodafone",
                Citta = "Roma",
                Regione = "Lazio",
                Provincia = "RM",
                Dimensione = DimensioneEnum.Media
            });
            Clienti.Add(new Cliente
            {
                ID = 2,
                Nome = "Bcc",
                Citta = "Milano",
                Regione = "Lombardia",
                Provincia = "MI",
                Dimensione = DimensioneEnum.Grande
            });
            Clienti.Add(new Cliente
            {
                ID = 3,
                Nome = "Telecom",
                Citta = "Roma",
                Regione = "Lazioe",
                Provincia = "RM",
                Dimensione = DimensioneEnum.Enterprise
            });
            #endregion


            #region Commessa
            //Inizializzo la lista dei clienti vuota
            Commesse = new List<Commessa>();

            //Adesso aggiungo 3 libri in memoria
            Commesse.Add(new Commessa
            {
                ID = 1,
                Nome = "Portale pubblico",
                Descrizione = "Descrizione Portale pubblico",
                DataInizio = new DateTime(2022 - 01 - 01),
                DataFine = new DateTime(2022 - 03 - 15),
                IDCliente =1

            });
            Commesse.Add(new Commessa
            {
                ID = 2,
                Nome = "Applicazione Mobile",
                Descrizione = "Descrizione Applicazione Mobile",
                DataInizio = new DateTime(2021 - 12 - 01),
                DataFine = new DateTime(2022 - 01 - 15),
                IDCliente = 2

            });
            Commesse.Add(new Commessa
            {
                ID = 3,
                Nome = "Portale privato",
                Descrizione = "Descrizione Portale privato",
                DataInizio = new DateTime(2022 - 02 - 01),
                DataFine = new DateTime(2022 - 03 - 15),
                IDCliente = 3

            });
            #endregion


            #region Dipendenti
            dipendenti = new List<Dipendente>();

            dipendenti.Add(new Dipendente
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
           
           


            

            dipendenti.Add(new Dipendente
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
            dipendenti.Add(new Dipendente
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
            #endregion

            #region Timesheet
            Timesheets = new List<Timesheet>();
            Timesheets.Add(new Timesheet
            {
                Id = "TS2",
                NumeroOre = 30,
                DataTimesheet = new DateTime(2022, 01, 13),
                IdAttivita = "A2",
                IdDipendente = "dip2"

            });

            Timesheets.Add(new Timesheet
            {
                Id = "TS3",
                NumeroOre = 40,
                DataTimesheet = new DateTime(2022, 04, 15),
                IdAttivita = "A3",
                IdDipendente = "dip3"

            });
            #endregion


            #region User
            Users = new List<User>();

            Users.Add(new User
            {
                Id = 1,
                Username = "martina.tiso",
                Password = "Academy2022",
                Role = Role.Administrator


            });

            Users.Add(new User
            {
                Id = 2,
                Username = "alessia.lionetto",
                Password = "novembre2022",
                Role = Role.Administrator


            });

            Users.Add(new User
            {
                Id = 3,
                Username = "maria.de.stefano",
                Password = "forGirls2022",
                Role = Role.Administrator


            });

            Users.Add(new User
            {
                Id = 4,
                Username = "diego.angelino",
                Password = "Pippo123",
                Role = Role.User


            });

            #endregion

            #region Attivita
            Attivita = new List<Attivita>();
            Attivita.Add(new Attivita
            {
                Id = "A1",
                Nome = "sviluppo frontend ",
                OreAllocate = 4,
                CostoSingolaOra = 8,
                IdCommessa = 1,
                IdDipendente = "dip3"
            });
            Attivita.Add(new Attivita
            {
                Id = "A2",
                Nome = "sviluppo frontend ",
                OreAllocate = 6,
                CostoSingolaOra = 9,
                IdCommessa = 2,
                IdDipendente = "dip2"
            });
            #endregion
        }






    }
}
