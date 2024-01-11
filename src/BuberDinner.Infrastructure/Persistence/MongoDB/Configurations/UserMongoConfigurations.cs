using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using BuberDinner.Infrastructure.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BuberDinner.Infrastructure.Persistence.MongoDB.Configurations;

public class UserMongoConfigurations
{
    public static void Register()
    {
        BsonClassMap.RegisterClassMap<AggregateRootId<UserId>>(classMap =>
        {
            classMap.MapIdField(x => x.Value)
                .SetSerializer(new MyUserIdSerializer());
        });

        BsonClassMap.RegisterClassMap<Entity<UserId>>(classMap =>
            classMap.UnmapMember(p => p.Id));

        //BsonClassMap.RegisterClassMap<Entity<UserId>>(classMap =>
        //{
        //    classMap.MapIdField(x => x.Id)
        //        .SetSerializer(new MyUserIdSerializer());
        //});

        BsonClassMap.RegisterClassMap<AggregateRoot<UserId>>();

        BsonClassMap.RegisterClassMap<UserId>();

        BsonClassMap.RegisterClassMap<User>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(p => p.FirstName)
                .SetElementName("first_name")
                .SetIsRequired(true);
            classMap.MapMember(p => p.LastName)
                .SetElementName("last_name")
                .SetIsRequired(true);
            classMap.MapMember(p => p.Email)
                .SetElementName("email")
                .SetIsRequired(true);
            classMap.MapMember(p => p.Password)
                .SetElementName("password")
                .SetIsRequired(true);
            classMap.MapMember(p => p.CreatedDateTime)
                .SetElementName("createdDateTime")
                .SetSerializer(new DateTimeSerializer(DateTimeKind.Local));
            classMap.MapMember(p => p.UpdateDateTime)
                .SetElementName("updateDateTime")
                .SetIgnoreIfNull(true)
                .SetShouldSerializeMethod(obj => ((User)obj).UpdateDateTime != null);

            classMap.SetIgnoreExtraElements(true);
        });
    }
}

public class MyUserIdSerializer : SerializerBase<UserId>
{
    public override UserId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadObjectId();
        return UserId.Create(value);
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, UserId value)
    {
        context.Writer.WriteObjectId(value.Value);
    }
}