using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;

namespace Application.Vehicle.Commands.CreateVehicle;
public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    private readonly IClientRepository _clientRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public CreateVehicleCommandValidator(IClientRepository clientRepository, 
                                         IVehicleRepository vehicleRepository)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));

        RuleFor(v => v.ClientId)
            .NotEmpty().WithMessage("ClientId is required.")
            .MustAsync(BeExistClientAsync).WithMessage("The specified client not exists.");

        RuleFor(v => new { v.ClientId, v.Plate })
            .MustAsync(BeUniqueClientPlateAsync).WithMessage("The combination between client and plate must be unique.");

        RuleFor(v => v.Model)
            .NotEmpty().WithMessage("Model is required.");

        RuleFor(v => v.Colour)
            .NotEmpty().WithMessage("Colour is required.");

        RuleFor(v => v.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer is required.");
        _vehicleRepository = vehicleRepository;
    }

    public async Task<bool> BeExistClientAsync(Guid clientId, CancellationToken cancellationToken) =>
        await _clientRepository.ExistAsync(l => l.Id == clientId, cancellationToken);
    public async Task<bool> BeUniqueClientPlateAsync(CreateVehicleCommand model, object test, CancellationToken cancellationToken) =>
        !await _vehicleRepository.ExistAsync(l => l.ClientId == model.ClientId && l.Plate == model.Plate, cancellationToken);
}
