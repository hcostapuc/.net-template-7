using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Client.Queries.GetClient;

namespace Application.Client.Queries.GetClientCollection;
public sealed record GetClientCollectionQuery():IRequest<IList<GetClientRootDto>>;