using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Client.Commands.CreateClient;

namespace Application.Client.Queries.GetClientDetail;
public sealed class GetClientDetailProfile : Profile
{
    public GetClientDetailProfile()
    {
        CreateMap<ClientEntity, GetClientDetailRootDto>()
            //.ForCtorParam(nameof(CreateClientCommand.Name), opt => opt.MapFrom(src => src.Name))
            //.ForCtorParam(nameof(CreateClientCommand.Address), opt => opt.MapFrom(src => src.Address))
            //.ForCtorParam(nameof(CreateClientCommand.Email), opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
        CreateMap<VehicleEntity, GetClientDetailVehicleDto>().ReverseMap();

    }
}
