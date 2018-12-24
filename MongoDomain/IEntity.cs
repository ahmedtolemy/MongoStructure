using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDomain
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
