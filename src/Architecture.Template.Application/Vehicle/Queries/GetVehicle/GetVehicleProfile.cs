using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle.Queries.GetVehicle;
public class GetVehicleProfile : Profile
{
    public GetVehicleProfile() =>
        CreateMap<VehicleEntity, GetVehicleRootDto>().ReverseMap();
}
