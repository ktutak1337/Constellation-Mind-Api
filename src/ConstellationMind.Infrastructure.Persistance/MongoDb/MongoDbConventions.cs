using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace ConstellationMind.Infrastructure.Persistance.MongoDb
{
    sealed class MongoDbConventions : IConventionPack
    {
        public IEnumerable<IConvention> Conventions
            => new List<IConvention>
                {
                    new IgnoreExtraElementsConvention(true),
                    new EnumRepresentationConvention(BsonType.String),
                    new CamelCaseElementNameConvention()
                };
    }
}
