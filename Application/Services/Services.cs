using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Services<T> where T : class
    {
        Task<T> Get<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        Task Save<T>(T inpust)
        {
            throw new NotImplementedException();
        }

        Task<T> Update<T>(Guid id, T value)
        {
            throw new NotImplementedException();
        }

        public Task Delete<T>(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
