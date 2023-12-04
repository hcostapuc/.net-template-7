using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public sealed class VehicleRepository: BaseRepository<VehicleEntity>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext context) : base(context)
    {

    }
}
