using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Application.Client.Queries.GetClient;

namespace Application.Client.Commands.CreateClient;
public sealed class CreateClientProfile: Profile
{
    public CreateClientProfile() =>
        CreateMap<ClientEntity, CreateClientCommand>()
            //.ForCtorParam(nameof(CreateClientCommand.Name), opt => opt.MapFrom(src => src.Name))
            //.ForCtorParam(nameof(CreateClientCommand.Address), opt => opt.MapFrom(src => src.Address))
            //.ForCtorParam(nameof(CreateClientCommand.Email), opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
}
