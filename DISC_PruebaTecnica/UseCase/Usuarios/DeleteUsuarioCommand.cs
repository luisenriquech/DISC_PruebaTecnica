using AutoMapper;
using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.General;
using DISC_PruebaTecnica.DTO.JWT;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Models;
using DISC_PruebaTecnica.UseCase.JWT;
using DISC_PruebaTecnica.Validaciones.Mensajes;
using MediatR;

namespace DISC_PruebaTecnica.UseCase.Usuarios
{
    public class DeleteUsuarioCommand : IInPutPort<int, SuccessResult>
    {
        public int RequestData { get; }

        public IOutPutPort<SuccessResult> OutPutPort { get; }

        public DeleteUsuarioCommand(int req, IOutPutPort<SuccessResult> outPutPort)
        {
            RequestData = req;
            OutPutPort = outPutPort;
        }

        public class DeleteUsuarioHandler : AsyncRequestHandler<DeleteUsuarioCommand>
        {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            public DeleteUsuarioHandler(IMapper mapper, IConfiguration configuration)
            {
                _mapper = mapper;
                _configuration = configuration;
            }

            protected async override Task Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    #region "Obtención del usuario"
                    PruebaTecnicaContext _context = new PruebaTecnicaContext();
                    var usr = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == request.RequestData);
                    #endregion
                    #region "Si el usuario existe"
                    if (usr != null)
                    {
                        _context.Remove(usr);
                        _context.SaveChanges();
                        request.OutPutPort.Handle(new SuccessResult(Utils.MensajesGenerales(11)));
                    }
                    #endregion
                    #region "Si el usuario no existe"
                    else
                    {
                        request.OutPutPort.Handle(new SuccessResult(true, Utils.MensajesGenerales(12)));
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
