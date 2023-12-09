using Application.Vehicle.Commands.UpdateVehicle;
using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderCommandValidator : AbstractValidator<CreateWashOrderCommand>
{
    private readonly IClientRepository _clientRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public CreateWashOrderCommandValidator(IClientRepository clientRepository,
                                         IVehicleRepository vehicleRepository)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));
        
        RuleFor(v => v.ClientId)
            .NotEmpty().WithMessage("ClientId is required.")
            .MustAsync(BeExistClientAsync).WithMessage("The specified client not exists.");

        RuleFor(v => v.VehicleId)
            .NotEmpty().WithMessage("VehicleId is required.")
            .MustAsync(BeExistVehicleAsync).WithMessage("The specified vehicle not exists.");

        RuleFor(v => new { v.ClientId, v.VehicleId })
          .MustAsync(BeValidCombineEntityAsync).WithMessage("The combination between client and vehicle must exist.");

    }
    public async Task<bool> BeExistClientAsync(Guid clientId, CancellationToken cancellationToken) =>
      await _clientRepository.ExistAsync(l => l.Id == clientId, cancellationToken);
    public async Task<bool> BeExistVehicleAsync(Guid vehicleId, CancellationToken cancellationToken) =>
      await _vehicleRepository.ExistAsync(l => l.Id == vehicleId, cancellationToken);
    public async Task<bool> BeValidCombineEntityAsync(CreateWashOrderCommand model, object _, CancellationToken cancellationToken) =>
      await _vehicleRepository.ExistAsync(l => l.ClientId == model.ClientId && l.Id == model.VehicleId, cancellationToken);
}
