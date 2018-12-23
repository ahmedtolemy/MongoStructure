using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDomain
{
    public class Module:Base
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public BsonArray Values { get; set; }

    }
}
