using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects;

namespace Application.Client.Queries.GetClientDetail;
public sealed record GetClientDetailVehicleDto(string Model,
                                               string Colour,
                                               string Plate,
                                               string Manufacturer);