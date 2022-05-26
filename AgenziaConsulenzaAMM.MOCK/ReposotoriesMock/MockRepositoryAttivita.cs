using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MOCK;
using System.Collections.Generic;
using System.Linq;

namespace AgenziaConsulenzaAMM.MOCK.ReposotoriesMock
{
    public class MockRepositoryAttivita : IRepositoryAttivita
    {
        private MockStorage storage;

        public MockRepositoryAttivita(MockStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<Attivita> FetchAll()
        {
            return storage.Attivita.ToList();
        }

        public IEnumerable<Attivita> FetchAttivityByDipendente(string IDdipendente)
        {
            throw new System.NotImplementedException();
        }
    }
}