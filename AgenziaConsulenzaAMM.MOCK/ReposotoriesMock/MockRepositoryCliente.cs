using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.MOCK.ReposotoriesMock
{
    public class MockRepositoryCliente : IRepositoryCliente
    {
       

        /// <summary>
        /// In memory storage
        /// </summary>
        public MockStorage Storage { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="storage">Dependency on storage</param>
        public MockRepositoryCliente(MockStorage storage)
        {
            //Archivio la dipendenza nella proprietà locale
            Storage = storage;
        }
        public bool Add(Cliente cliente)
        {
            try
            {
                Storage.Clienti.Add(cliente);

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Delete(Cliente entity)
        {
            try
            {
                Storage.Clienti.Remove(entity);

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public IEnumerable<Cliente> FetchAll()
        {
            return Storage.Clienti
                    .OrderBy(b => b.Nome)
                    .ToList();
        }

        public bool Update(Cliente entity)
        {
            foreach (var d in Storage.Clienti)
            {
                if (d.ID == entity.ID)
                {
                    d.ID = entity.ID;
                    d.Nome = entity.Nome;
                    d.Citta = entity.Citta;
                    d.Regione = entity.Regione;
                    d.Provincia = entity.Provincia;
                    d.Dimensione = entity.Dimensione;
                    
                }
                return true;
            }
            return false;
        }
    }
}
