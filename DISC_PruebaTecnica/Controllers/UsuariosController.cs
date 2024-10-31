using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.General;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Negocio;
using DISC_PruebaTecnica.UseCase.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DISC_PruebaTecnica.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("users")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> users([FromBody] UserDto userDto)
        {
            #region "Verificación del token"
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = JWTFunctions.validateToken(identity);
            GenericPresenter presenter = new();
            #endregion
            #region "Si el token es correcto"
            if (rToken != null)
            {
                #region "Si tiene permiso de administrador para esta sección"
                if (rToken.IdRol == 1)
                {
                    await _mediator.Send(new PostUsuarioCommand(userDto, presenter));
                    if (presenter.Content.Error)
                    {
                        return StatusCode(409, presenter.Content);
                    }
                    return StatusCode(201, presenter.Content);
                }
                #endregion
                #region "Si no tiene permiso para esta sección"
                else
                {
                    return StatusCode(401, new SuccessResult(true, "No tiene permiso para esta sección"));
                }
                #endregion
            }
            #endregion
            #region "Si el token no es correcto"
            else
            {
                return StatusCode(402, new SuccessResult(true, "Credenciales incorrectas"));
            }
            #endregion
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto, int id)
        {
            #region "Verificación del token"
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = JWTFunctions.validateToken(identity);
            GenericPresenter presenter = new();
            #endregion
            #region "Si el token es correcto"
            if (rToken != null)
            {
                #region "Si tiene permiso de administrador para esta sección"
                if (rToken.IdRol == 1)
                {
                    Tuple<UserDto, int> req = new Tuple<UserDto, int>(userDto, id);
                    await _mediator.Send(new PatchUsuarioCommand(req, presenter));
                    if (presenter.Content.Error)
                    {
                        return StatusCode(409, presenter.Content);
                    }
                    return StatusCode(201, presenter.Content);
                }
                #endregion
                #region "Si no tiene permiso para esta sección"
                else
                {
                    return StatusCode(401, new SuccessResult(true, "No tiene permiso para esta sección"));
                }
                #endregion
            }
            #endregion
            #region "Si el token no es correcto"
            else
            {
                return StatusCode(402, new SuccessResult(true, "Credenciales incorrectas"));
            }
            #endregion
        }


        [HttpGet]
        public async Task<IActionResult> UsersList()
        {
            #region "Verificación del token"
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = JWTFunctions.validateToken(identity);
            GenericPresenter presenter = new();
            #endregion
            #region "Si el token es correcto"
            if (rToken != null)
            {
                #region "Si tiene permiso de administrador para esta sección"
                if (rToken.IdRol == 1)
                {
                    await _mediator.Send(new GetListaUsuariosQuery(null, presenter));
                    if (presenter.Content.Error)
                    {
                        return StatusCode(409, presenter.Content);
                    }
                    return StatusCode(200, presenter.Content);
                }
                #endregion
                #region "Si no tiene permiso para esta sección"
                else
                {
                    return StatusCode(401, new SuccessResult(true, "No tiene permiso para esta sección"));
                }
                #endregion

            }
            #endregion
            #region "Si el token no es correcto"
            else
            {
                return StatusCode(402, new SuccessResult(true, "Credenciales incorrectas"));
            }
            #endregion
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> userById(int id)
        {
            #region "Verificación del token"
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = JWTFunctions.validateToken(identity);
            GenericPresenter presenter = new();
            #endregion
            #region "Si el token es correcto"
            if (rToken != null)
            {
                #region "Si no es administrador, sólo puede consultar su mismo usuario"
                if (rToken.IdRol != 1)
                {
                    id = rToken.IdUsuario;
                }
                #endregion
                #region "Consulta y retorno del usuario"
                await _mediator.Send(new GetUsuarioQuery(id, presenter));
                if (presenter.Content.Error)
                {
                    return StatusCode(409, presenter.Content);
                }
                return StatusCode(302, presenter.Content);
                #endregion
            }

            #endregion
            #region "Si el token no es correcto"
            else
            {
                return StatusCode(402, new SuccessResult(true, "Credenciales incorrectas"));
            }
            #endregion
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteByID(int id)
        {
            #region "Verificación del token"
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = JWTFunctions.validateToken(identity);
            GenericPresenter presenter = new();
            #endregion
            #region "Si el token es correcto"
            if (rToken != null)
            {
                #region "Si es administrador puede eliminar"
                if (rToken.IdRol == 1)
                {
                    #region "Consulta y retorno del usuario"
                    await _mediator.Send(new DeleteUsuarioCommand(id, presenter));
                    if (presenter.Content.Error)
                    {
                        return StatusCode(409, presenter.Content);
                    }
                    return StatusCode(200, presenter.Content);
                    #endregion
                }
                #endregion
                #region "Si no es administrador no tiene permiso"
                else
                {
                    return StatusCode(401, new SuccessResult(true, "No tiene permiso para esta sección"));
                }
                #endregion
            }
            #endregion
            #region "Si el token no es correcto"
            else
            {
                return StatusCode(402, new SuccessResult(true, "Credenciales incorrectas"));
            }
            #endregion
        }

    }
}
