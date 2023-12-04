using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
