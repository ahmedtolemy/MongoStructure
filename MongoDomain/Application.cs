using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MongoDomain
{
    public class Application:Base
    {
        public string Name { get; set; }
        public string Image  { get; set; }
        public List<string> ModulesIds { get; set; }
        public List<Module> Modules { get; set; }
    }
}
