using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDomain
{
    public class Base : IEntity
    {
        public ObjectId Id { get ; set; }
      //  public byte[] RowVersion { get; set ; }
        public DateTime CreatedOn { get ; set; }
        public DateTime ModifiedOn { get ; set ; }
        [BsonExtraElements]
        public BsonDocument ExtraElement { get; set; }
    }
}
