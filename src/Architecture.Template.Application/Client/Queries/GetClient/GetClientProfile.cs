using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Queries.GetClient;
public class GetClientProfile : Profile
{
    public GetClientProfile() =>
        CreateMap<ClientEntity, GetClientRootDto>().ReverseMap();
}
