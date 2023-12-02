using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TodoItem.Commands.UpdateTodoItem;

namespace Application.Client.Commands.UpdateClient;
internal static class UpdateClientExtension
{
    internal static void UpdateEntityFieldsFrom(this ClientEntity clientEntity, UpdateClientCommand updateClientCommand)
    {
        clientEntity.Name = updateClientCommand.Name;
        clientEntity.Address = updateClientCommand.Address;
    }
}
