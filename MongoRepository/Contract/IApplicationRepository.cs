using MongoDomain;
using MongoRepository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoRepository.Contract
{
    public interface IApplicationRepository : IRepository<Application>
    {
    }
}
