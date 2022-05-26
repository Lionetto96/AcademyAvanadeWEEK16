using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.MOCK.ReposotoriesMock
{
    public class MockRepositoryDipendente : IRepositoryDipendente
    {
        /// <summary>
        /// In memory storage
        /// </summary>
        public MockStorage Storage { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="storage">Dependency on storage</param>
        public MockRepositoryDipendente(MockStorage storage)
        {
            //Archivio la dipendenza nella proprietà locale
            Storage = storage;
        }

        public bool Add(Dipendente entity)
        {
            try
            {
                Storage.dipendenti.Add(entity);
                
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
                Storage.dipendenti.Remove(entity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Dipendente> FetchAll()
        {
            return Storage.dipendenti.ToList();
        }

        public bool Update(Dipendente entity)
        {
            //var exists = Storage.dipendenti.Equals(entity.Id);

            //if (exists)

            //    throw new Exception($"Employee with id {entity.Id} already exists");

            //else

            //{

            //    var index = Storage.dipendenti.FirstOrDefault(e => e.Id == entity.Id);

            //    Storage.dipendenti.Remove(index);

            //    Storage.dipendenti.Add(entity);

            //    return true;

            //}
            foreach (var d in Storage.dipendenti)
            {
                if (d.Id == entity.Id)
                {
                    d.Id = entity.Id;
                    d.Nome = entity.Nome;
                    d.Cognome = entity.Cognome;
                    d.DataNascita = entity.DataNascita;
                    d.DataAssunzione=entity.DataAssunzione;
                    d.Email= entity.Email;
                    d.CostoOrarioAzienda=entity.CostoOrarioAzienda;
                    return true;
                }

                
            }
            return false;
        }
    }
}
