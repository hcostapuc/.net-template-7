using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;

namespace Application.Client.Queries.GetClient;
public sealed record GetClientRootDto(Guid Id,
                                       string Name,
                                       string Email,
                                       string Address) : IMapFrom<ClientEntity>;