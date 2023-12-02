using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Entities;
public sealed class WashOrderEntity: BaseAuditableEntity
{
    public required ClientEntity Client { get; set; }
    public required PriorityLevel PriorityLevel { get; set; }
    public string? Description { get; set; }
    //If needed to add more robustness fell free to create a service class
    public IList<string> ServiceCollection { get; private set; } = new List<string>();

    private readonly bool _done;
    public bool Done
    {
        get => _done; set
        {

            if (value && !_done)
                AddDomainEvent(new WashOrderCompletedEvent(this));
        }
    }
}
