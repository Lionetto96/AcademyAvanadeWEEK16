using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.Core.Interfaces
{
    public interface IRepositoryAttivita
    {
        IEnumerable<Attivita> FetchAll();
        IEnumerable<Attivita> FetchAttivityByDipendente(string IDdipendente);
    }
}
