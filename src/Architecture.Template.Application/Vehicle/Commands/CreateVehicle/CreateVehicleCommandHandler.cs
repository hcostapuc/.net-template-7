using Domain.Interfaces.Repository;

namespace Application.Vehicle.Commands.CreateVehicle;
public sealed class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                      IMapper mapper)
    {
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));
    }
    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleEntity = _mapper.Map<CreateVehicleCommand, VehicleEntity>(request);
        await _vehicleRepository.InsertAsync(vehicleEntity, cancellationToken);
        return vehicleEntity.Id;
    }
}