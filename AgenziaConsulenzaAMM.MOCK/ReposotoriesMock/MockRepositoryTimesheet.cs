using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.MOCK.ReposotoriesMock
{
    
    
    public class MockRepositoryTimesheet : IRepositoryTimesheet
    {
        public MockStorage Storage { get; }
        public MockRepositoryTimesheet(MockStorage storage)
        {
            Storage = storage;
        }
        public bool Add(Timesheet entity)
        {
            try
            {
                Storage.Timesheets.Add(entity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Timesheet timesheet)
        {
            try
            {
                Storage.Timesheets.Remove(timesheet);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Timesheet> FetchAll()
        {
            return Storage.Timesheets
                .ToList();
        }

        public bool Update(Timesheet timesheet)
        {
            
            foreach (var ts in Storage.Timesheets)
            {
                if (ts.Id == timesheet.Id)
                {
                    ts.Id = timesheet.Id;
                    ts.NumeroOre = timesheet.NumeroOre;
                    ts.DataTimesheet = timesheet.DataTimesheet;
                    ts.IdDipendente = timesheet.IdDipendente;
                    ts.IdAttivita = timesheet.IdAttivita;
                    
                    return true;
                }
            }
            return false;


        }
    }
}
