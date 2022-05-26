using AgenziaConsulenzaAMM.Core.BusinessLayer;
using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.MOCK;
using AgenziaConsulenzaAMM.MOCK.ReposotoriesMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.TEST
{
    public  class ClasseDipendenze
    {
        
        public ClasseDipendenze()
        {
            MockStorage storage = new MockStorage();
            IRepositoryDipendente rd = new MockRepositoryDipendente(storage);
            IRepositoryCliente rc = new MockRepositoryCliente(storage);
            IRepositoryTimesheet rt = new MockRepositoryTimesheet(storage);
            IRepositoryAttivita ra = new MockRepositoryAttivita(storage);
            IRepositoryCommesse rco = new MockRepositoryCommessa(storage);
            IRepositoryUser ru = new MockRepositoryUser(storage);
            MainBusinessLayer = new MainBusinessLayer(ra,rc,rco,rd,rt,ru);
        }

        public MainBusinessLayer MainBusinessLayer { get; set; }
       
    }
}
