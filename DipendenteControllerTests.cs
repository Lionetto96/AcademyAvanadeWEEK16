using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.EF.Repositories;
using AgenziaConsulenzaAMM.MOCK;
using AgenziaConsulenzaAMM.MOCK.ReposotoriesMock;
using AgenziaConsulenzaAMM.MVC.Controllers;
using AgenziaConsulenzaAMM.TEST.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AgenziaConsulenzaAMM.TEST
{
    public class DipendenteControllerTests : ClasseDipendenze
    {
        
        

        [Fact]
        public void ShouldFetchAllBeOkWithAtLeastOneElement()
        {
            //USER STORY 23#: Come utente anonimo voglio poter vedere la lista dei dipendenti presenti 

            //BEHAVIOR: Chiamando la API che risponde all'indirizzo http://.../api/Dipendente/FetchAll dovrei
            //ottenere un 200-OK (quindi una conferma) e il JSON risultante dovrebbe contenere almeno
            //un oggetto dipendente, e questo dovrebbe avere valorizzati i campi 

            //*** ARRANGE (setup)

            //Inizializzo le dipendenze
            

            //Creazione di una istanza di controller (MVC)
            //DipendenteController controller = new DipendenteController(layer);

            //*** ACT 


            var result = MainBusinessLayer.FetchAllDipendenti().ToList();

            //*** ASSERT

            

            //Dovrebbe esserci almeno un oggetto nella lista
            Assert.True(result.Count() > 0);

            //Dovrebbero esserci i campi stabiliti
            for(int i = 0; i < result.Count(); i++)
            {
                Assert.NotNull(result[i]);
            }
           

        }
        [Fact]
        public void ShouldCreateBeOkWithIncrementedElements()
        {
            //USER STORY #67: Come utente amministratore vorrei poter aggiungere un nuovo dipendente 

            //BEHAVIOR: Chiamando un endpoint api/Dipendenti/Create e passando una request con nome, 
            //cognome, email, datanascita, dataassunzione, mansione, costosingolaora ottere un 200-OK e avere nella risposta
            //un oggetto di tipo Dipendente

            //*** ARRANGE

            //Inizializzo le dipendenze

           
            var li=MainBusinessLayer.FetchAllDipendenti();

            //Devo contare quanti dipendenti ci sono nello storage PRIMA di creare
            var countBefore= li.Count();
            
            
            //Creazione di una request di esempio
            var request = new Dipendente
            {
               Id = "dip4",
               Nome ="Giulio",
               Cognome ="Rossi",
               DataNascita=new DateTime(1990,09,23),
               DataAssunzione=new DateTime(2020,07,03),
               Email="rossi1@gmail.com",
               Mansione=MansioneEnum.Manager,
               CostoOrarioAzienda=12m


            };

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            MainBusinessLayer.AddNewDipendente(request);

            //*** ASSERT



            //Devo contare quanti dipendenti ci sono nello storage DOPO aver creato
            var li2 = MainBusinessLayer.FetchAllDipendenti();
            var countAfter =li2.Count();

            //Verifico che i record siano aumentati
            Assert.Equal(countBefore + 1, countAfter);

            
          

            
        }

        [Fact]
        public void ShouldEditBeOk()
        {
            //USER STORY 73 TASK 77#: Come utente amministratore vorrei poter aggiungere un nuovo dipendente 

            //BEHAVIOR: Chiamando un endpoint api/Dipendenti/Create e passando una request con nome, 
            //cognome, email, datanascita, dataassunzione, mansione, costosingolaora ottere un 200-OK e avere nella risposta
            //un oggetto di tipo Dipendente

            //*** ARRANGE

           





            //Creazione di una request di esempio
            
            var li=MainBusinessLayer.FetchAllDipendenti();
            var request = li.Single(x => x.Id == "dip1");
            request.Mansione = MansioneEnum.Manager;

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)

            var b=MainBusinessLayer.UpdateDipendente(request);
                       
            //*** ASSERT

            //Verifico che il dip1 sia stato modificato 
            Assert.True(b);





        }
        [Fact]
        public void ShouldDeleteBeOkWithDecrementedElements()
        {
            //USER STORY 79 TASK 84#: Come utente amministratore vorrei poter aggiungere un nuovo dipendente 

            //BEHAVIOR: Chiamando un endpoint api/Dipendenti/delete e passando una request con nome, 
            //cognome, email, datanascita, dataassunzione, mansione, costosingolaora ottere un 200-OK e avere nella risposta
            //un oggetto di tipo bool

            //*** ARRANGE

            //Inizializzo le dipendenze

            //MockStorage storage = new MockStorage();
            //Creazione di una istanza di controller (MVC)
            //DipendenteController controller = new DipendenteController(MainBusinessLayer);
            var li = MainBusinessLayer.FetchAllDipendenti();
            //Devo contare quanti dipendenti ci sono nello storage PRIMA di eliminare 
            var countBefore = li.Count();


            //Creazione di una request di esempio
            
            var request = li.Single(x=>x.Id=="dip1");

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            MainBusinessLayer.DeleteDipendente(request);

            //*** ASSERT



            //Devo contare quanti dipendenti ci sono nello storage DOPO aver creato
            var li2=MainBusinessLayer.FetchAllDipendenti();
            var countAfter = li2.Count();

            //Verifico che i record siano diminuiti
            Assert.Equal(countBefore - 1 , countAfter);





        }
    }
}
