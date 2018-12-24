using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDomain
{
    public class Base : IEntity
    {
        public string Id { get ; set; }
        public DateTime CreatedOn { get ; set; }
        public DateTime ModifiedOn { get ; set ; }
        [BsonExtraElements]
        public BsonDocument ExtraElement { get; set; }
    }
}
