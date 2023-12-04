using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WashOrder.Commands.DeleteWashOrder;
public sealed record ConcludeWashOrderCommand(Guid Id): IRequest;