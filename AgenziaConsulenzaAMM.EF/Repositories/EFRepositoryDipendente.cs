using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryDipendente : IRepositoryDipendente
    {
        public EFRepositoryDipendente()
        {

        }
        private readonly AgenziaDBContext _dbContext;
        public EFRepositoryDipendente(AgenziaDBContext context)
        {
            _dbContext = context;
        }
        public bool Add(Dipendente entity)
        {
            try
            {
                _dbContext.Dipendenti.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Delete(Dipendente entity)
        {
            try
            {
                _dbContext.Dipendenti.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Dipendente> FetchAll()
        {
            return _dbContext.Dipendenti.ToList();
        }

        public bool Update(Dipendente entity)
        {
            try
            {
                _dbContext.Dipendenti.Update(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
