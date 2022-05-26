using AgenziaConsulenzaAMM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.MOCK.ReposotoriesMock
{
    public class MockRepositoryCommessa :IRepositoryCommesse
    {
        /// <summary>
        /// In memory storage
        /// </summary>
        public MockStorage Storage { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="storage">Dependency on storage</param>
        public MockRepositoryCommessa(MockStorage storage)
        {
            //Archivio la dipendenza nella proprietà locale
            Storage = storage;
        }
    }
}
