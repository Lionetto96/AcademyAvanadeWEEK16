using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public DimensioneEnum Dimensione { get; set; }

        public IList<Commessa> Commesse { get; set; } = new List<Commessa>();

       

    }
    public enum DimensioneEnum
    {
        Piccola,
        Media,
        Grande,
        Enterprise

    }
}

