using Domain.Interfaces.Repository;

namespace Application.Vehicle.Commands.UpdateVehicle;
public sealed class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
{
    private readonly IVehicleRepository _vehicleRepository;
    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository) =>
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));
    public async Task Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleEntity = await _vehicleRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, vehicleEntity, nameof(vehicleEntity));

        vehicleEntity.UpdateEntityFieldsFrom(request);

        await _vehicleRepository.UpdateAsync(vehicleEntity, cancellationToken);
    }
}