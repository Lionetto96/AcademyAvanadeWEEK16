using AgenziaConsulenzaAMM.Core.Models;

namespace AgenziaConsulenzaAMM.MVC.Models.Cliente
{
    public class ClienteViewModel
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }

        public DimensioneEnum Dimensione { get; set; }
    }
}
