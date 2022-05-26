using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryTimesheet : IRepositoryTimesheet
    {
        private AgenziaDBContext _context;
        public EFRepositoryTimesheet()
        {

        }
        public EFRepositoryTimesheet(AgenziaDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Timesheet> FetchAll()
        {
            return _context.Timesheets
                .Include(d => d.Dipendente)
                .Include(a => a.Attivita)
                .ToList();
        }
        public bool Add(Timesheet newtimesheet)
        {
            try
            {
              
                _context.Timesheets.Add(newtimesheet);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Timesheet timesheetToBeDelete)
        {
            if (timesheetToBeDelete == null)
                return false;

            try
            {              

                _context.Timesheets.Remove(timesheetToBeDelete);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
             

        public bool Update(Timesheet updatedTimesheet)
        {
            try
            {

                _context.Timesheets.Update(updatedTimesheet);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
