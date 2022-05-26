using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer 
    {
        private IRepositoryAttivita _repositoryAttivita;
        private IRepositoryCliente _repositoryCliente;
        private IRepositoryCommesse _repositoryCommesse;
        private IRepositoryDipendente _repositoryDipendente;
        private IRepositoryTimesheet _repositoryTimesheet;
        private IRepositoryUser _repositoryUser;

        
        public MainBusinessLayer(IRepositoryAttivita repositoryAttivita, IRepositoryCliente repositoryCliente, IRepositoryCommesse repositoryCommesse, IRepositoryDipendente repositoryDipendente, IRepositoryTimesheet repositoryTimesheet, IRepositoryUser repositoryUser )
        {
            _repositoryAttivita = repositoryAttivita;
            _repositoryCliente = repositoryCliente;
            _repositoryCommesse = repositoryCommesse;
            _repositoryDipendente = repositoryDipendente;
            _repositoryTimesheet = repositoryTimesheet;
            _repositoryUser = repositoryUser;

        }
        //
        #region Cliente
        public bool CreateCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            return _repositoryCliente.Add(newCliente);
        }

        public bool DeleteCliente(Cliente deleteCliente)
        {
            if (deleteCliente != null)
                return _repositoryCliente.Delete(deleteCliente);

            return false;
        }

        public IEnumerable<Cliente> FetchAllClienti()
        {
            return _repositoryCliente.FetchAll();
        }

        public bool UpdateCliente(Cliente updateCliente)
        {
            if (updateCliente == null)
                return false;
            return _repositoryCliente.Update(updateCliente);
        }

        #endregion

        #region Dipendenti
        public IEnumerable<Dipendente> FetchAllDipendenti()
        {
            
            return _repositoryDipendente.FetchAll();
        }

        public bool AddNewDipendente(Dipendente dipendente)
        {
            
            return _repositoryDipendente.Add(dipendente);
        }
        public bool UpdateDipendente(Dipendente updateDipendente)
        {
            if (updateDipendente == null)
                return false;
            return _repositoryDipendente.Update(updateDipendente);
        }
        public bool DeleteDipendente(Dipendente deleteDipendente)
        {
            if (deleteDipendente == null)
                return false;
            return _repositoryDipendente.Delete(deleteDipendente);
        }
        #endregion

        #region Timesheet
        public IEnumerable<Timesheet> FetchAllTimesheet()
        {
            return _repositoryTimesheet.FetchAll();
        }

        public bool AddNewTimesheet(Timesheet newTimesheet)
        {
            if (newTimesheet == null)
                return false;

            return _repositoryTimesheet.Add(newTimesheet);
        }

        public bool UpdateTimesheet(Timesheet updatedTimesheet)
        {
            if (updatedTimesheet == null)
                return false;

            return _repositoryTimesheet.Update(updatedTimesheet);
        }

        public bool DeleteTimesheet(Timesheet timesheetToBeDelete)
        {
            if (timesheetToBeDelete == null)
                return false;

            return _repositoryTimesheet.Delete(timesheetToBeDelete);
        }
        #endregion


        #region User
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return _repositoryUser.GetUserByUsername(username);
        }


        #endregion

        public IEnumerable<Attivita> FetchAllAttivities()
        {
            return _repositoryAttivita.FetchAll();
        }


    }
}
