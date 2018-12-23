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

               // map.SetIdMember(map.GetMemberMap(c => c.Id));
                //map.GetMemberMap(x => x.ModifiedOn).SetDefaultValue(DateTime.Now);
                //  map.GetMemberMap(x => x.CreatedOn).SetDefaultValue(DateTime.Now);
                map.MapExtraElementsMember(x => x.ExtraElement);
            });
            BsonClassMap.RegisterClassMap<Application>(map =>
            {
               
                map.AutoMap();
               
                
               // map.MapIdProperty(x => x.Id).SetIdGenerator();
              // map.MapExtraElementsMember(x=>x.ExtraElement);

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
