
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.ComponentModel;

namespace AgenziaConsulenzaAMM.MVC.Models.Timesheet
{
    public class TimesheetViewModel
    {
        public string Id { get; set; }    
        [DisplayName("Numero Ore")]
        public double NumeroOre { get; set; }
        [DisplayName("Data Timesheet")]
        public string DataTimesheet { get; set; }
        public string Attivita { get; set; }
        [DisplayName("Id Attività")]
        public string IdAttivita { get; set; }
        public string Dipendente { get; set; }
        [DisplayName("Id Dipendente")]
        public string IdDipendente { get; set; }
    }
}
