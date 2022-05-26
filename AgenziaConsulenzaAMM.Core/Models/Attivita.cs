using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Models
{
    public class Attivita
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int OreAllocate { get; set; }
        public double CostoSingolaOra { get; set; }
        public IList<Timesheet> Timesheets { get; set; }=new List<Timesheet>();

        //navigationProperty
        public Commessa Commessa { get; set; }
        public int IdCommessa { get; set; }

        public Dipendente Dipendente { get; set; }
        public string IdDipendente  { get; set; }
        
        
    }
}
