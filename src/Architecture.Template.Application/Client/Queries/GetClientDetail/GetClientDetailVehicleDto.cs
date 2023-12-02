using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.ValueObjects;

namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailVehicleDto(string Model,
                                               Colour Colour,
                                               string Manufacturer) : IMapFrom<VehicleEntity>;