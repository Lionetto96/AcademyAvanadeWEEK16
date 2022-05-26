using AgenziaConsulenzaAMM.Core.Interfaces;
using AgenziaConsulenzaAMM.Core.Models;
using AgenziaConsulenzaAMM.MOCK;

namespace AgenziaConsulenzaAMM.MOCK.ReposotoriesMock
{
    public class MockRepositoryUser : IRepositoryUser
    {
        private MockStorage storage;

        public MockRepositoryUser(MockStorage storage)
        {
            this.storage = storage;
        }

        public User GetUserByUsername(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}