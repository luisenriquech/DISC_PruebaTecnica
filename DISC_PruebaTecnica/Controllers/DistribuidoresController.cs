using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DISC_PruebaTecnica.Controllers
{
    public class DistribuidoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DistribuidoresController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
