using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle.Commands.CreateVehicle;
public sealed class CreateVehicleProfile: Profile
{
    public CreateVehicleProfile() =>
        CreateMap<VehicleEntity, CreateVehicleCommand>()
            //.ForCtorParam(nameof(CreateVehicleCommand.Name), opt => opt.MapFrom(src => src.Name))
            //.ForCtorParam(nameof(CreateVehicleCommand.Address), opt => opt.MapFrom(src => src.Address))
            //.ForCtorParam(nameof(CreateVehicleCommand.Email), opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
}
