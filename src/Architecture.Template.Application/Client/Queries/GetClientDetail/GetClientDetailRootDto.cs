using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;

namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailRootDto(Guid Id,
                                            string Name,
                                            string Email,
                                            string Address) : IMapFrom<ClientEntity>
{
    public IList<GetClientDetailVehicleDto> VehicleCollection { get; init; } = new List<GetClientDetailVehicleDto>();
}