using Domain.Interfaces.Repository;

namespace Application.WashOrder.Commands.CreateWashOrder;
public sealed class CreateWashOrderCommandValidator : AbstractValidator<CreateWashOrderCommand>
{
    private readonly IClientRepository _clientRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IWashOrderRepository _washOrderRepository;
    public CreateWashOrderCommandValidator(IClientRepository clientRepository,
                                         IVehicleRepository vehicleRepository,
                                         IWashOrderRepository washOrderRepository)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));
        _washOrderRepository = washOrderRepository ?? Guard.Against.Null(washOrderRepository, nameof(washOrderRepository));

        RuleFor(v => v.ClientId)
            .NotEmpty().WithMessage("ClientId is required.")
            .MustAsync(BeExistClientAsync).WithMessage("The specified client not exists.");

        RuleFor(v => v.VehicleId)
            .NotEmpty().WithMessage("VehicleId is required.")
            .MustAsync(BeExistVehicleAsync).WithMessage("The specified vehicle not exists.")
          .MustAsync(BeUniqueWashAsync).WithMessage("Already exist a wash order opened to the specific vehicle.");

        RuleFor(v => new { v.ClientId, v.VehicleId })
          .MustAsync(BeValidCombineEntityAsync).WithMessage("The combination between client and vehicle must exist.");
    }
    public async Task<bool> BeExistClientAsync(Guid id, CancellationToken cancellationToken) =>
      await _clientRepository.ExistAsync(l => l.Id == id, cancellationToken);
    public async Task<bool> BeExistVehicleAsync(Guid id, CancellationToken cancellationToken) =>
      await _vehicleRepository.ExistAsync(l => l.Id == id, cancellationToken);
    public async Task<bool> BeValidCombineEntityAsync(CreateWashOrderCommand model, object _, CancellationToken cancellationToken) =>
      await _vehicleRepository.ExistAsync(l => l.ClientId == model.ClientId && l.Id == model.VehicleId, cancellationToken);
    public async Task<bool> BeUniqueWashAsync(Guid id, CancellationToken cancellationToken) =>
      !await _washOrderRepository.ExistAsync(l => l.VehicleId == id && l.Status == Domain.Enums.StatusOrder.Open, cancellationToken);
}
