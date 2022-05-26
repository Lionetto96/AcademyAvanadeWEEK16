using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Models
{
    public  class Timesheet
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Numero Ore")]
        public double NumeroOre { get; set; }
        [Required]
        [Display(Name = "Data Timesheet")]
        public DateTime DataTimesheet { get; set; }
        public Attivita Attivita { get; set; }
        [Display(Name = "Id Attività")]
        public string IdAttivita { get; set; }
        public Dipendente Dipendente { get; set; }
        [Display(Name = "Id Dipendente")]
        public string IdDipendente { get; set; }

    }
}
