using Domain.Interfaces.Repository;

namespace Application.Vehicle.Commands.DeleteVehicle;
public sealed class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
{
    private readonly IVehicleRepository _vehicleRepository;
    public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository) =>
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));
    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleEntity = await _vehicleRepository.SelectAsync(x => x.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, vehicleEntity, nameof(vehicleEntity.Id));

        await _vehicleRepository.DeleteAsync(vehicleEntity, cancellationToken);
    }
}