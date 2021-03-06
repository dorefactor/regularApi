using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RegularApi.Domain.Model
{
    public class Application
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public ApplicationSetup ApplicationSetup { get; set; }
    }
}