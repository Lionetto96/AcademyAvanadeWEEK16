using AgenziaConsulenzaAMM.Core.Models;
using System.ComponentModel;

namespace AgenziaConsulenzaAMM.MVC.Models.Timesheet
{
    public class TimesheetCreateViewModel
    {
        public string Id { get; set; }
        [DisplayName("Numero Ore")]
        public double NumeroOre { get; set; }
        [DisplayName("Data Timesheet")]
        public string DataTimesheet { get; set; }
        [DisplayName("Attività")]
        public string IdAttivita { get; set; }
        [DisplayName("Dipendente")]
        public string IdDipendente { get; set; }
        
        
    }
}
