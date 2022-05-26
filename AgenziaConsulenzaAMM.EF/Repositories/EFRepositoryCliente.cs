using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryCliente : IRepositoryCliente

    {
        public EFRepositoryCliente()
        {

        }
        private AgenziaDBContext _context;

        public EFRepositoryCliente(AgenziaDBContext context)
        {
            _context = context;
        }
        public bool Add(Cliente cliente)
        {
            try
            {
                _context.Clienti.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Delete(Cliente cliente)
        {
            try
            {
                var ct = _context.Clienti.Find(cliente);

                if (ct != null)
                    _context.Clienti.Remove(cliente);

                _context.SaveChanges();

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public IEnumerable<Cliente> FetchAll()
        {

            return _context.Clienti
                    .OrderBy(b => b.Nome)
                    .ToList();
        }

        public bool Update(Cliente cliente)
        {
            _context.Clienti.Update(cliente);
            _context.SaveChanges();
            return true;
        }
    }
}
