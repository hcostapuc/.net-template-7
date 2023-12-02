using MediatR;

using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Common;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _sender = null!;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}