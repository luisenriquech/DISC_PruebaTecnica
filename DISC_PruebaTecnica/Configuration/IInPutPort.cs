using MediatR;

namespace DISC_PruebaTecnica.Configuration
{
    public interface IInPutPort<InteractionRequestType, InteractionResponseType> : IRequest
    {
        public InteractionRequestType RequestData { get; }

        public IOutPutPort<InteractionResponseType> OutPutPort { get; }
    }
}
