using Domain.Interfaces.Repository;

namespace Application.Vehicle.Queries.GetVehicle;
public sealed class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, GetVehicleRootDto>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    public GetVehicleQueryHandler(IVehicleRepository vehicleRepository,
                                 IMapper mapper)
    {
        _vehicleRepository = vehicleRepository ?? Guard.Against.Null(vehicleRepository, nameof(vehicleRepository));
        _mapper = mapper ?? Guard.Against.Null(mapper, nameof(mapper));

    }
    public async Task<GetVehicleRootDto> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
    {
        var vehicleEntity = await _vehicleRepository.SelectAsync(x => x.Plate == request.Plate, cancellationToken);
        Guard.Against.NotFound(request.Plate, vehicleEntity, nameof(vehicleEntity.Id));
        return _mapper.Map<VehicleEntity, GetVehicleRootDto>(vehicleEntity);
    }
}