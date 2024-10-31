using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DISC_PruebaTecnica.Controllers
{
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
