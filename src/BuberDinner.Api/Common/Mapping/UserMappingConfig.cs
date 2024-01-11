using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<User, MenuResponse>()
        //    .Map(dest => dest.Id, src => src.Id.Value)
        //    .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
        //    .Map(dest => dest.HostId, src => src.HostId.Value)
        //    .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
        //    .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value));
    }
}
