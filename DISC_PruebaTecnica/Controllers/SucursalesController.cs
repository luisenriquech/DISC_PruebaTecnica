using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DISC_PruebaTecnica.Controllers
{
    public class SucursalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SucursalesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
