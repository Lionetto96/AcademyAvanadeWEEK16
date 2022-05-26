using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.EF.Repositories
{
    public class EFRepositoryUser : IRepositoryUser
    {
        private readonly AgenziaDBContext _context;
        public EFRepositoryUser()
        {

        }
        public EFRepositoryUser(AgenziaDBContext context)
        {
            _context = context;
        }
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return _context.Users.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
