using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AgenziaConsulenzaAMM.MVC.Models.Dipendente
{
    public class DipendenteViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        [DisplayName("Data di nascita")]
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        [DisplayName("Data di assunzione")]
        public DateTime DataAssunzione { get; set; }
        public MansioneEnum Mansione { get; set; }
        [DisplayName("Costo Orario Azienda")]
        public decimal CostoOrarioAzienda { get; set; }
        //public IList<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
        //public IList<Attivita> Attivita { get; set; } = new List<Attivita>();
    }
}
