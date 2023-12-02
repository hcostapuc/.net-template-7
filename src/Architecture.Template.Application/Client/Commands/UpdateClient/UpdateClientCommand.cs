using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Commands.UpdateClient;
public sealed record UpdateClientCommand(Guid Id,
                                         string Name,
                                         string Address) : IRequest;