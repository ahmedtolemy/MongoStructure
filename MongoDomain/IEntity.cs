using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDomain
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
       // byte[] RowVersion { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
