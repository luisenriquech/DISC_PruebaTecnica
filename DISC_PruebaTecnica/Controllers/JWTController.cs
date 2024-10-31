using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.JWT;
using DISC_PruebaTecnica.UseCase.JWT;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DISC_PruebaTecnica.Controllers
{
    [ApiController]
    [Route("JWT")]

    public class JWTController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JWTController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> PostToken(usrJWTdto usuario)
        {
            GenericPresenter presenter = new();
            await _mediator.Send(new PostTokenCommand(usuario, presenter));
            if (presenter.Content.Error)
            {
                return StatusCode(401, presenter.Content);
            }
            return StatusCode(200, presenter.Content);
        }
    }
}
