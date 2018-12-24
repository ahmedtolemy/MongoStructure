using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoPresistence.Mapping
{
    class ApplicationMap
    {
        public void Map()
        {
            BsonClassMap.RegisterClassMap<Base>(map =>
            {
                map.AutoMap();
                map.GetMemberMap(x => x.CreatedOn).SetSerializer(new DateTimeSerializer(DateTimeKind.Utc));
                map.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(BsonType.ObjectId));
                map.MapExtraElementsMember(x => x.ExtraElement);
            });
            BsonClassMap.RegisterClassMap<Application>(map =>
            {
                map.AutoMap();
            });
           
            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());

            ConventionRegistry.Register(
               "My Custom Conventions",
               pack,
               t => t.FullName.StartsWith("MyNamespace."));
        }
    }
}
