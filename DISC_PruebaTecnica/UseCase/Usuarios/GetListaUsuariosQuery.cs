using AutoMapper;
using DISC_PruebaTecnica.Configuration;
using DISC_PruebaTecnica.DTO.General;
using DISC_PruebaTecnica.DTO.JWT;
using DISC_PruebaTecnica.DTO.Usuarios;
using DISC_PruebaTecnica.Models;
using DISC_PruebaTecnica.Validaciones.Mensajes;
using MediatR;

namespace DISC_PruebaTecnica.UseCase.Usuarios
{
    public class GetListaUsuariosQuery : IInPutPort<string, SuccessResult>
    {
        public string RequestData { get; }

        public IOutPutPort<SuccessResult> OutPutPort { get; }

        public GetListaUsuariosQuery(string req, IOutPutPort<SuccessResult> outPutPort)
        {
            RequestData = req;
            OutPutPort = outPutPort;
        }

        public class GetListaUsuariosHandler : AsyncRequestHandler<GetListaUsuariosQuery>
        {
            public IConfiguration _configuration;
            private readonly IMapper _mapper;

            public GetListaUsuariosHandler(IMapper mapper, IConfiguration configuration)
            {
                _mapper = mapper;
                _configuration = configuration;
            }

            protected async override Task Handle(GetListaUsuariosQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    #region "Obtención de la lista de usuarios"
                    PruebaTecnicaContext _context = new PruebaTecnicaContext();
                    var usr = _context.Usuarios.ToList();
                    #endregion
                    #region "Si la lista no está vacía"
                    if (usr != null && usr.Count > 0)
                    {
                        var listaUsuarios = _mapper.Map<List<User1Dto>>(usr);
                        request.OutPutPort.Handle(new SuccessResult(listaUsuarios));

                    }
                    #endregion
                    #region "Si la lista está vacía"
                    else
                    {
                        request.OutPutPort.Handle(new SuccessResult(true,Utils.MensajesGenerales(10)));
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
