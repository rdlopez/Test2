using Domain;
using Persistence;
using Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services
{
    public class TestService : ITestService 
    {
        private readonly IRepository<UploadFile> repository;
        public TestService(IRepository<UploadFile> repository) 
        {
            this.repository = repository;
        }

        public Task Update(UploadFile file) 
        {
            return this.repository.Update(file);
        }

        public IList GetAll()
        {
            return this.repository.GetAll().ToList();
        }
    }
}
