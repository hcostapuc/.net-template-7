namespace Application.Client.Commands.UpdateClient;
internal static class UpdateClientExtension
{
    internal static void UpdateEntityFieldsFrom(this ClientEntity clientEntity, UpdateClientCommand updateClientCommand)
    {
        clientEntity.Name = updateClientCommand.Name;
        clientEntity.PhoneNumber = updateClientCommand.PhoneNumber;
        clientEntity.Address = updateClientCommand.Address;
    }
}
