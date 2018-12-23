using MongoDomain;
using MongoPresistence;
using MongoRepository.Contract;
using MongoRepository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoRepository.Implementation
{
    public class ApplicationRepository:Repository<Application>,IApplicationRepository
    {
        public ApplicationRepository(MongoContext context) : base(context)
        {
        }
    }
}
