using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Models
{
    public class Commessa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public int IDCliente { get; set; }
        public Cliente Cliente { get; set; }
        public IList<Attivita> Attivities { get; set; }
    }
}
