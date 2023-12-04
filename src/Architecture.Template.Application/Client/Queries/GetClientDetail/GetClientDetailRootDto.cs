using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailRootDto(Guid Id,
                                            string Name,
                                            string Email,
                                            string Address)
{
    public IList<GetClientDetailVehicleDto> VehicleCollection { get; init; } = new List<GetClientDetailVehicleDto>();

}