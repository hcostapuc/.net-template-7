using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Commands.DeleteClient;
public sealed record DeleteClientCommand(Guid Id): IRequest;