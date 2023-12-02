using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailQuery(Guid Id):IRequest<GetClientDetailRootDto>;