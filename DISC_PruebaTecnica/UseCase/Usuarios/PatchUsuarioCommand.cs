using AutoMapper;
using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.General;
using DISC_PruebaTecnica.DTO.JWT;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Models;
using DISC_PruebaTecnica.Negocio;
using DISC_PruebaTecnica.UseCase.JWT;
using DISC_PruebaTecnica.Validaciones.Mensajes;
using DISC_PruebaTecnica.Validaciones.Usuarios;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DISC_PruebaTecnica.UseCase.Usuarios
{
    public class PatchUsuarioCommand : IInPutPort<Tuple<UserDto, int>, SuccessResult>
    {
        public Tuple<UserDto, int> RequestData { get; }

        public IOutPutPort<SuccessResult> OutPutPort { get; }

        public PatchUsuarioCommand(Tuple<UserDto, int> req, IOutPutPort<SuccessResult> outPutPort)
        {
            RequestData = req;
            OutPutPort = outPutPort;
        }

        public class PatchUsuarioHandler : AsyncRequestHandler<PatchUsuarioCommand>
        {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            public PatchUsuarioHandler(IMapper mapper, IConfiguration configuration)
            {
                _mapper = mapper;
                _configuration = configuration;
            }

            protected async override Task Handle(PatchUsuarioCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    #region "Búsqueda de usuario"
                    PruebaTecnicaContext _context = new PruebaTecnicaContext();
                    var usuario = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == request.RequestData.Item2);
                    #endregion
                    #region "Si el usuario existe"
                    if (usuario != null)
                    {
                        #region "Validación de estructura de datos"
                        var validator = new PatchUsuarioValidation();
                        ValidationResult result = validator.Validate(request.RequestData.Item1);
                        #endregion
                        #region "Si la validación fue correcta" 
                        if (result.IsValid)
                        {
                            #region "Comprobación de no duplicidad"
                            var usr = _context.Usuarios.FirstOrDefault(x => (x.Email == request.RequestData.Item1.Email | x.Usuario1 == request.RequestData.Item1.Usuario) & x.IdUsuario != request.RequestData.Item2);
                            #endregion
                            #region "Si el registro ya es duplicado"
                            if (usr != null)
                            {
                                request.OutPutPort.Handle(new SuccessResult(true, Utils.MensajesGenerales(15)));
                            }
                            #endregion
                            #region "Si el registro no es duplicado"
                            else
                            {
                                #region "Comprobación de ids"
                                string error = string.Empty;
                                if (_context.RolUsuarios.FirstOrDefault(x => x.IdRol == request.RequestData.Item1.IdRol) == null)
                                {
                                    error += Utils.MensajesGenerales(8);
                                }
                                if (_context.PuestoUsuarios.FirstOrDefault(x => x.IdPuesto == request.RequestData.Item1.IdPuesto) == null)
                                {
                                    error += Utils.MensajesGenerales(9);
                                }
                                #endregion
                                #region "Si los Ids fueron correctos"
                                if (error.IsNullOrEmpty())
                                {
                                    usuario.Usuario1 = request.RequestData.Item1.Usuario;
                                    usuario.Email = request.RequestData.Item1.Email;
                                    usuario.Password = JWTFunctions.EncryptToSHA256(request.RequestData.Item1.Password);
                                    usuario.IdRol = request.RequestData.Item1.IdRol;
                                    usuario.IdPuesto = request.RequestData.Item1.IdPuesto;                                    
                                    _context.Usuarios.Update(usuario);
                                    _context.SaveChanges();
                                    request.OutPutPort.Handle(new SuccessResult(Utils.MensajesGenerales(13)));
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
                    #endregion
                    #region "Si el usuario no existe"
                    else
                    {
                        request.OutPutPort.Handle(new SuccessResult(true, Utils.MensajesGenerales(14)));
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
