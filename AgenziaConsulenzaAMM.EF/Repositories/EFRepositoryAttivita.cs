using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryAttivita :IRepositoryAttivita
    {
        private AgenziaDBContext _context;

        public EFRepositoryAttivita()
        {
        }

        public EFRepositoryAttivita(AgenziaDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Attivita> FetchAll()
        {
            return _context.Attivities.ToList();
        }

        public IEnumerable<Attivita> FetchAttivityByDipendente(string IDdipendente)
        {
            if (IDdipendente == null)
                return null;
             return _context.Attivities.Where(c=>c.IdDipendente == IDdipendente).ToList();
        }
    }
}
