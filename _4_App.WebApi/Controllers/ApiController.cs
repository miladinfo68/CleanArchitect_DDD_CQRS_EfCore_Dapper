using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace _4_App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => 
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
