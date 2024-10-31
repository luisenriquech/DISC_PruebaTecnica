using AutoMapper;
using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.General;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Models;
using DISC_PruebaTecnica.Validaciones.Mensajes;
using MediatR;

namespace DISC_PruebaTecnica.UseCase.Usuarios
{
    public class GetUsuarioQuery : IInPutPort<int, SuccessResult>
    {
        public int RequestData { get; }

        public IOutPutPort<SuccessResult> OutPutPort { get; }

        public GetUsuarioQuery(int req, IOutPutPort<SuccessResult> outPutPort)
        {
            RequestData = req;
            OutPutPort = outPutPort;
        }

        public class GetUsuarioHandler : AsyncRequestHandler<GetUsuarioQuery>
        {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            public GetUsuarioHandler(IMapper mapper, IConfiguration configuration)
            {
                _mapper = mapper;
                _configuration = configuration;
            }

            protected async override Task Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    #region "Obtención del usuario"
                    PruebaTecnicaContext _context = new PruebaTecnicaContext();
                    var usr = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == request.RequestData);
                    #endregion
                    #region "Si el usuario existe"
                    if (usr != null )
                    {
                        var usuario = _mapper.Map<User1Dto>(usr);
                        request.OutPutPort.Handle(new SuccessResult(usuario));
                    }
                    #endregion
                    #region "Si el usuario no existe"
                    else
                    {
                        request.OutPutPort.Handle(new SuccessResult(true, Utils.MensajesGenerales(10)));
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
