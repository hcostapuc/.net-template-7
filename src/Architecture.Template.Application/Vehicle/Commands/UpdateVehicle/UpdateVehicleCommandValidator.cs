using Domain.Interfaces.Repository;

namespace Application.Vehicle.Commands.UpdateVehicle;
public sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    private readonly IClientRepository _clientRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public UpdateVehicleCommandValidator(IClientRepository clientRepository,
                                         IVehicleRepository vehicleRepository)
    {
        _clientRepository = clientRepository ?? Guard.Against.Null(clientRepository, nameof(clientRepository));
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));

        RuleFor(v => v.ClientId)
            .NotEmpty().WithMessage("ClientId is required.")
            .MustAsync(BeExistClientAsync).WithMessage("The specified client not exists.");

        RuleFor(v => v.Plate)
           .NotEmpty().WithMessage("Plate is required.")
           .MustAsync(BeUniquePlateAsync).WithMessage("The specified plate already exists.");

        RuleFor(v => v.Model)
            .NotEmpty().WithMessage("Model is required.");

        RuleFor(v => v.Colour)
            .NotEmpty().WithMessage("Colour is required.");

        RuleFor(v => v.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer is required.");
    }
    //TODO: try a better way to run a batch of simple rules and then the rules that involves get something on db side to do only once request
    public async Task<bool> BeExistClientAsync(Guid id, CancellationToken cancellationToken) =>
        await _clientRepository.ExistAsync(l => l.Id == id, cancellationToken);
    public async Task<bool> BeUniquePlateAsync(string plate, CancellationToken cancellationToken) =>
        !await _vehicleRepository.ExistAsync(l => l.Plate == plate, cancellationToken);
}