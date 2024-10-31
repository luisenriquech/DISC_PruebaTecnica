using AutoMapper;
using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.General;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Models;
using DISC_PruebaTecnica.Negocio;
using DISC_PruebaTecnica.Validaciones.Mensajes;
using DISC_PruebaTecnica.Validaciones.Usuarios;
using FluentValidation.Results;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace DISC_PruebaTecnica.UseCase.Usuarios
{
    public class PostUsuarioCommand : IInPutPort<UserDto, SuccessResult>
    {
        public UserDto RequestData { get; }

        public IOutPutPort<SuccessResult> OutPutPort { get; }

        public PostUsuarioCommand(UserDto req, IOutPutPort<SuccessResult> outPutPort)
        {
            RequestData = req;
            OutPutPort = outPutPort;
        }

        public class PostUsuarioHandler : AsyncRequestHandler<PostUsuarioCommand>
        {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            public PostUsuarioHandler(IMapper mapper, IConfiguration configuration)
            {
                _mapper = mapper;
                _configuration = configuration;
            }

            protected async override Task Handle(PostUsuarioCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    #region "Validación de estructura de datos"
                    var validator = new PostUsuarioValidation();
                    ValidationResult result = validator.Validate(request.RequestData);
                    #endregion
                    #region "Si la validación fue correcta" 
                    if (result.IsValid)
                    {
                        #region "Comprobación de no duplicidad"
                        PruebaTecnicaContext _context = new PruebaTecnicaContext();
                        var usr = _context.Usuarios.FirstOrDefault(x => x.Email == request.RequestData.Email | x.Usuario1 == request.RequestData.Usuario);
                        #endregion
                        #region "Si el registro ya es duplicado"
                        if (usr != null)
                        {
                            request.OutPutPort.Handle(new SuccessResult(true, Utils.MensajesGenerales(4)));
                        }
                        #endregion
                        #region "Si el registro no es duplicado"
                        else
                        {
                            #region "Comprobación de ids"
                            string error = string.Empty;
                            if (_context.RolUsuarios.FirstOrDefault(x => x.IdRol == request.RequestData.IdRol) == null)
                            {
                                error += Utils.MensajesGenerales(8);
                            }
                            if (_context.PuestoUsuarios.FirstOrDefault(x => x.IdPuesto == request.RequestData.IdPuesto) == null)
                            {
                                error += Utils.MensajesGenerales(9);
                            }
                            #endregion
                            #region "Si los Ids fueron correctos"
                            if (error.IsNullOrEmpty())
                            {
                                Usuario nuevoUsuario = new Usuario() { Email = request.RequestData.Email, FechaCreacion = DateTime.Now, IdPuesto = request.RequestData.IdPuesto, IdRol = request.RequestData.IdRol, Password = JWTFunctions.EncryptToSHA256(request.RequestData.Password), Activo = true, Usuario1 = request.RequestData.Usuario };
                                _context.Usuarios.Add(nuevoUsuario);
                                _context.SaveChanges();
                                request.OutPutPort.Handle(new SuccessResult(Utils.MensajesGenerales(5)));
                            }
                            #endregion
                            #region "Si los ids no fueron correctos"
                            else
                            {
                                request.OutPutPort.Handle(new SuccessResult(true, error));
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                    #region "Si la validación no fue correcta"
                    else
                    {
                        request.OutPutPort.Handle(new SuccessResult(true, result.Errors, Utils.MensajesGenerales(2)));
                    }
                    #endregion
                }

                catch (Exception ex)
                {
                    request.OutPutPort.Handle(new SuccessResult(true, Utils.MensajesGenerales(1) + ex.Message));
                }
            }
        }
    }
}
