using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.BusinessLayer
{
    public interface IBusinessLayer
    {

        #region CRUD Dipendente 
        IEnumerable<Dipendente> FetchAllDipendenti();
        bool AddNewDipendente (Dipendente newDipendente);
        bool UpdateDipendente(Dipendente updateDipendente);
        bool DeleteDipendente (Dipendente deleteDipendente);    
        #endregion


        #region CRUD Cliente
        IEnumerable<Cliente> FetchAllClienti();
        bool CreateCliente(Cliente newCliente);
        bool DeleteCliente(Cliente deleteCliente);
        bool UpdateCliente(Cliente updateCliente);
        
        #endregion


        #region CRUD Timesheet
        IEnumerable<Timesheet> FetchAllTimesheet();
        bool AddNewTimesheet(Timesheet newTimesheet);
        bool UpdateTimesheet(Timesheet updatedTimesheet);
        bool DeleteTimesheet(Timesheet timesheetToBeDelete);
        #endregion

        #region Attivita
        IEnumerable<Attivita> FetchAllAttivities();
        #endregion


        #region Users

        User GetUserByUsername(string username);

        #endregion
    }
}
