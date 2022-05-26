using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Models
{
    public class Dipendente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        public DateTime DataAssunzione { get; set; }
        public MansioneEnum Mansione { get; set; }
        public decimal CostoOrarioAzienda { get; set; }
        public IList<Timesheet> Timesheets { get; set; }=new List<Timesheet>();
        public IList<Attivita> Attivita { get; set; }= new List<Attivita>();


    }


    public enum MansioneEnum
    {
        [Display(Name="Manager")]
        Manager, 
        [Display(Name = "Senior Consultant")]
        SeniorConsultant,
        [Display(Name = "Consultant")]
        Consultant,
        [Display(Name = "Senior Analyst")]
        SeniorAnalyst,
        [Display(Name = "Analyst")]
        Analyst

    }
}

