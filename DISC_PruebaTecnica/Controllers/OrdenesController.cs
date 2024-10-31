using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DISC_PruebaTecnica.Controllers
{
    public class OrdenesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdenesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
