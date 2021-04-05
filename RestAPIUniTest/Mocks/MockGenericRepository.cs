using RestAPIApplication.Interfaces;
using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using RestAPIApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIUnitTest.Mocks
{
    public class MockGenericRepository : IGenericRepository<Shop>
    {
        public Task AddToSalesHistory(BoughtProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task ContextSaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleateById(int id)
        {
            throw new NotImplementedException();
        }

        public Shop FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Shop>> GetAll()
        {
            //moq
            throw new NotImplementedException();
        }

        public Shop GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProducts(Shop entity, int amount)
        {
            throw new NotImplementedException();
        }

        public Task UpserAsync(Shop entity)
        {
            throw new NotImplementedException();
        }
    }
}
