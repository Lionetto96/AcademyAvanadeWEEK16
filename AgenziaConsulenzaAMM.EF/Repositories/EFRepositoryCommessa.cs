using AgenziaConsulenzaAMM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryCommessa :IRepositoryCommesse
    {
        private AgenziaDBContext _context;
        public EFRepositoryCommessa()
        {

        }
        public EFRepositoryCommessa(AgenziaDBContext context)
        {
            _context = context;
        }
    }
}
