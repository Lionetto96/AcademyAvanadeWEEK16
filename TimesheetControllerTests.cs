using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgenziaConsulenzaAMM.TEST
{

    public class TimesheetControllerTests : ClasseDipendenze
    {
        [Fact]
        public void ShouldFetchAllBeOkWithAtLeastOneElement()
        {
            //USER STORY 5#-Task: Come utente anonimo voglio poter vedere la lista dei timesheet presenti 

             

            //*** ARRANGE (setup)

            //Inizializzo le dipendenze


            //Creazione di una istanza di controller (MVC)
            //TimesheetController controller = new TimesheetController(layer);

            //*** ACT 
            var result = MainBusinessLayer.FetchAllTimesheet().ToList();

            //*** ASSERT



            //Dovrebbe esserci almeno un oggetto nella lista
            Assert.True(result.Count() > 0);

            //Dovrebbero esserci i campi stabiliti
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.NotNull(result[i]);
            }


        }


        [Fact]
        public void ShouldCreateBeOkWithIncrementedElements()
        {
            //USER STORY #98: Come utente amministratore vorrei poter aggiungere un nuovo Timesheet 


            //*** ARRANGE

            //Inizializzo le dipendenze

           var li = MainBusinessLayer.FetchAllTimesheet();
            //Creazione di una istanza di controller (MVC)
            //TimesheetController controller = new TimesheetController(MainBusinessLayer);

            //Devo contare quanti timesheet ci sono nello storage PRIMA di creare
            var countBefore = li.Count();


            //Creazione di una request di esempio
            var request = new Timesheet
            {
                Id = "TS3",
                NumeroOre = 25,
                DataTimesheet = new DateTime(2022, 07, 19),
                IdAttivita = "A3",
                IdDipendente = "dip1"

            };

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            MainBusinessLayer.AddNewTimesheet(request);

            //*** ASSERT



            //Devo contare quanti dipendenti ci sono nello storage DOPO aver creato
            var li2 = MainBusinessLayer.FetchAllTimesheet();
            var countAfter = li2.Count();
            //Verifico che i record siano aumentati
            Assert.Equal(countBefore + 1, countAfter);

        }

        [Fact]
        public void ShouldEditBeOk()
        {
            //USER STORY #: Come utente amministratore vorrei poter aggiornare un timesheet

            //*** ARRANGE

            //Creazione di una request di esempio

            var li = MainBusinessLayer.FetchAllTimesheet();
            var request = li.Single(x => x.Id == "TS2");
            request.NumeroOre=25;

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)

            var b = MainBusinessLayer.UpdateTimesheet(request);

            //*** ASSERT

            //Verifico che il dip1 sia stato modificato 
            Assert.True(b);

        }

        [Fact]
        public void ShouldDeleteBeOkWithDecrementedElements()
        {
            //USER STORY #: Come utente amministratore vorrei poter eliminare un timesheet 


            //*** ARRANGE

            //Inizializzo le dipendenze

            //MockStorage storage = new MockStorage();
            //Creazione di una istanza di controller (MVC)
            //TimesheetController controller = new TimesheetController(MainBusinessLayer);
            var li = MainBusinessLayer.FetchAllTimesheet();
            //Devo contare quanti timesheet ci sono nello storage PRIMA di eliminare 
            var countBefore = li.Count();


            //Creazione di una request di esempio

            var request = li.Single(x => x.Id == "TS2");

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            MainBusinessLayer.DeleteTimesheet(request);

            //*** ASSERT

            //Devo contare quanti timesheet ci sono nello storage DOPO aver creato
            var li2 = MainBusinessLayer.FetchAllTimesheet();
            var countAfter = li2.Count();

            //Verifico che i record siano diminuiti
            Assert.Equal(countBefore - 1, countAfter);
        }
    }
}

