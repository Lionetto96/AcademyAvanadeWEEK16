using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgenziaConsulenzaAMM.CONSOLE
{
    public class Program
    {
        private static IRepositoryDipendente repDipendente = new EFRepositoryDipendente();
        private static IRepositoryAttivita repoAttivita = new EFRepositoryAttivita();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            bool continua = true;
            while (continua)
            {
                int scelta = Menu();
                continua = AnalizzaScelta(scelta);

            }

            int Menu()
            {
                Console.WriteLine("**********************");
                Console.WriteLine("Menù");
                Console.WriteLine("\n Funzionalità dipendenti");
                Console.WriteLine("\n[1] visualizza dipendenti" +
                    "\n[2] inserire nuovo dipendente" +
                    "\n[3] modificare un dipendente" +
                    "\n[4] eliminare dipendente"+
                    "\n[5] recap attività per dipendente per mese");

                

                Console.WriteLine("\n [0] esci");
                Console.WriteLine("**********************");

                int scelta;
                Console.WriteLine("inserisci la tua scelta");
                while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 5))
                {
                    Console.WriteLine("scelta errata!! Inserisci un numero compreso tra 0 e 5 ");
                }
                return scelta;


            }

            bool AnalizzaScelta(int scelta)
            {
                switch (scelta)
                {
                    case 1:
                        VisualizzaDipendenti();
                        break;
                    case 2:
                        AggiungiDipendente();
                        
                        break;
                    case 3:
                        ModificaDipendente();
                        break;
                    case 4:
                        EliminaDipendente();
                        break;
                    case 5:
                        RecapAttivitaDipendentePerMese();
                        break;
                   
                    case 0:
                        return false;
                        //default:
                        //    Console.WriteLine("scelta non valida");
                        //    break;
                }
                return true;
            }
        }

        private static void RecapAttivitaDipendentePerMese()
        {
            VisualizzaDipendenti();
            string id = Helpers.CheckStringa("IdDipendente da visualizzare");
            repoAttivita.FetchAttivityByDipendente(id);
           
        }








        #region Dipendenti 
        private static IEnumerable<Dipendente> VisualizzaDipendenti()
        {
            IEnumerable<Dipendente> lista = repDipendente.FetchAll().ToList();
            if (lista.Count() == 0)
            {
                Console.WriteLine("lista vuota");
            }
            else
            {
                foreach (var i in lista)
                {
                    Console.WriteLine(i);
                }
            }
            return lista;
        }

        private static void AggiungiDipendente()
        {
            string nome=Helpers.CheckStringa("nome dipendente");
            string cognome = Helpers.CheckStringa("cognome dipendente");
            string email = Helpers.CheckStringa("email dipendente");
            DateTime dataNascita = Helpers.CheckData("data nascita");
            DateTime dataAssunzione = Helpers.CheckData("data di assunzione");
            string mansione;
            do
            {
                Console.WriteLine($"scegli mansione:   {MansioneEnum.Consultant} \n {MansioneEnum.Analyst} \n {MansioneEnum.SeniorConsultant} \n {MansioneEnum.SeniorAnalyst} \n {MansioneEnum.Manager}");

                mansione = Console.ReadLine();

            } while (mansione != "Consultant" && mansione != "Analyst" && mansione != "SeniorConsultant" && mansione != "SeniorAnalyst" && mansione != "Manager");
            MansioneEnum mansEnum = (MansioneEnum)Enum.Parse(typeof(MansioneEnum), mansione);
            decimal costo = Helpers.CheckDecimal("costo orario azienda");
            Dipendente newDip=new Dipendente();
            newDip.Nome = nome;
            newDip.Cognome = cognome;
            newDip.Mansione = mansEnum;
            newDip.DataNascita= dataNascita;
            newDip.DataAssunzione= dataAssunzione;
            newDip.Email= email;
            newDip.CostoOrarioAzienda = costo;
            repDipendente.Add(newDip);
            VisualizzaDipendenti();


        }
        private static void ModificaDipendente()
        {
            Console.WriteLine("inserisci id dipendente da modificare");
            VisualizzaDipendenti();
            string id=Console.ReadLine();
            var dip=repDipendente.FetchAll().Single(x=>x.Id==id);
            var result=repDipendente.Update(dip);
            if (result == false)
                Console.WriteLine("dipendente non modificato correttamente");
            Console.WriteLine($"dipendente {id} modificato correttamente");
            VisualizzaDipendenti();
            

        }
        private static void EliminaDipendente()
        {
            Console.WriteLine("inserisci id dipendente da eliminare");
            VisualizzaDipendenti();
            string id = Console.ReadLine();
            var dip = repDipendente.FetchAll().Single(x => x.Id == id);
            var result = repDipendente.Delete(dip);
            if (result == false)
                Console.WriteLine("dipendente non eliminato correttamente");
            Console.WriteLine($"dipendente {id} eliminato correttamente");
            VisualizzaDipendenti();
        }

        #endregion
    }
}