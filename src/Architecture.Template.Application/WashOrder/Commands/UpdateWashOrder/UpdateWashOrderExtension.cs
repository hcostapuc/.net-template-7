namespace Application.WashOrder.Commands.UpdateWashOrder;
internal static class UpdateWashOrderExtension
{
    internal static void UpdateEntityFieldsFrom(this WashOrderEntity washOrderEntity, UpdateWashOrderCommand updateWashOrderCommand)
    {
        washOrderEntity.Price = updateWashOrderCommand.Price;
        washOrderEntity.Description = updateWashOrderCommand.Description;
        washOrderEntity.WashType = updateWashOrderCommand.WashType;
    }
}
