using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Infrastructure.Services;
using MongoDB.Bson.Serialization;

namespace BuberDinner.Infrastructure.Persistence.MongoDB.Configurations;

public class MenuMongoConfigurations
{
    public static void Register()
    {
        BsonClassMap.RegisterClassMap<AggregateRootId<MenuId>>(classMap =>
           classMap.UnmapMember(p => p.Value));
        BsonClassMap.RegisterClassMap<Entity<MenuId>>(classMap =>
            classMap.UnmapMember(p => p.Id));
        BsonClassMap.RegisterClassMap<AggregateRoot<MenuId, Guid>>(classMap =>
            classMap.UnmapMember(p => p.Id));

        BsonClassMap.RegisterClassMap<MenuId>();

        BsonClassMap.RegisterClassMap<Menu>(classMap =>
        {
            classMap.AutoMap();

            classMap.MapMember(p => p.Name).SetElementName("name");
            classMap.MapMember(p => p.Description).SetElementName("description");
            classMap.MapMember(p => p.AverageRating).SetElementName("averageRating");
            classMap.MapMember(p => p.MenuReviewIds).SetElementName("menuReviewIds");
            classMap.MapMember(p => p.DinnerIds).SetElementName("dinnerIds");
            classMap.MapMember(p => p.Sections).SetElementName("sections");
            classMap.MapMember(p => p.HostId).SetElementName("hostId");
            classMap.MapMember(p => p.CreatedDateTime).SetElementName("createdDateTime")
                .SetDefaultValue(new DateTimeProvider().UtcNow);
            classMap.MapMember(p => p.UpdateDateTime).SetElementName("updateDateTime");

            classMap.SetIgnoreExtraElements(true);
        });
    }
}
