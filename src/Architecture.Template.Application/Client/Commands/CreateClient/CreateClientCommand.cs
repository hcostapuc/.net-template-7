using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Client.Commands.CreateClient;
public sealed record CreateClientCommand(string Name,
                                         string Email,
                                         string Address): IRequest<Guid>;