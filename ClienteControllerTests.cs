using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static AgenziaConsulenzaAMM.Core.Models.Cliente;

namespace AgenziaConsulenzaAMM.TEST
{
    public class ClienteControllerTests : ClasseDipendenze
    {
        [Fact]
        public void ShouldFetchAllBeOkWithAtLeastOneElement()
        {
            //USER STORY 36#: Come utente anonimo voglio poter vedere la lista dei clienti presenti 

            //BEHAVIOR: Chiamando la API che risponde all'indirizzo http://.../api/clienti/FetchAll dovrei
            //ottenere un 200-OK (quindi una conferma) e il JSON risultante dovrebbe contenere almeno
            //un oggetto cliente, e questo dovrebbe avere valorizzati i campi 

            //*** ARRANGE (setup)

            //Inizializzo le dipendenze


            //Creazione di una istanza di controller (MVC)
            //ClienteController controller = new ClienteController(layer);

            //*** ACT 
            var result = MainBusinessLayer.FetchAllClienti().ToList();


            //*** ASSERT

            Assert.True(result.Count() > 0);
            //Dovrebbe esserci almeno un oggetto nella lista

            //Dovrebbero esserci i campi stabiliti
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.NotNull(result[i]);
            }
        }
        [Fact]
        public void ShouldCreateBeOkWithIncrementedElements()
        {
            //USER STORY #49: Come utente amministratore vorrei poter aggiungere un nuovo cliente 

            //BEHAVIOR: Chiamando un endpoint api/Cliente/Create e passando una request con nome, 
            //citta, regione, provincia, dimesione ottere un 200-OK e avere nella risposta
            //un oggetto di tipo Cliente

            //*** ARRANGE

            var li = MainBusinessLayer.FetchAllClienti();

            //Devo contare quanti clienti ci sono nello storage PRIMA di creare
            var countBefore = li.Count();
            //Creazione di una request di esempio
            var request = new Cliente
            {
                ID = 1,
                Nome = "TIM",
                Citta = "Firenze",
                Regione = "Toscana",
                Provincia = "FI",
                Dimensione =DimensioneEnum.Enterprise,


            };

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)

            MainBusinessLayer.CreateCliente(request);


            //*** ASSERT



            //Devo contare quanti clienti ci sono nello storage DOPO aver creato
            var li2 = MainBusinessLayer.FetchAllClienti();
            var countAfter = li2.Count();

            //Verifico che i record siano aumentati
            Assert.Equal(countBefore + 1, countAfter);


        }

        [Fact]
        public void ShouldEditBeOk()
        {
            //USER STORY #: Come utente amministratore vorrei poter modificare un cliente 

            //BEHAVIOR: Chiamando un endpoint api/cliente/Edit e passando una request con nome, 
            //citta, regione, provincia, dimensione  ottere un 200-OK e avere nella risposta
            //un oggetto di tipo cliente

            //*** ARRANGE



            //Creazione di una request di esempio
           
     
            var li = MainBusinessLayer.FetchAllClienti();
            var request = li.FirstOrDefault(x => x.ID == 2);
            request.Dimensione = DimensioneEnum.Piccola;

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)

            var b = MainBusinessLayer.UpdateCliente(request);

            //*** ASSERT

            //Verifico che il dip1 sia stato modificato 
            Assert.True(b);





        }
        [Fact]
        public void ShouldDeleteBeOkWithDecrementedElements()
        {
            //USER STORY #: Come utente amministratore vorrei poter cancellare un cliente 

            //BEHAVIOR: Chiamando un endpoint api/Cliente/delete e passando una request con nome, 
            //cognome,regione,provincia,dimensione ottere un 200-OK e avere nella risposta
            //un oggetto di tipo bool

            //*** ARRANGE

            //Inizializzo le dipendenze

            
            var li = MainBusinessLayer.FetchAllClienti();
            //Devo contare quanti clienti ci sono nello storage PRIMA di eliminare 
            var countBefore = li.Count();


            //Creazione di una request di esempio

            var request = li.FirstOrDefault(x => x.ID == 2);

            //*** ACT

            //Ottengo il risultato della chiamata al server (sul metodo richiesto)
            MainBusinessLayer.DeleteCliente(request);

            //*** ASSERT



            //Devo contare quanti clienti ci sono nello storage DOPO aver creato
            var li2 = MainBusinessLayer.FetchAllClienti();
            var countAfter = li2.Count();

            //Verifico che i record siano diminuiti
            Assert.Equal(countBefore - 1, countAfter);





        }
    }

}
