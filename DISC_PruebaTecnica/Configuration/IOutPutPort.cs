namespace DISC_PruebaTecnica.Configuration
{
    public interface IOutPutPort<InteractionResponseType>
    {
        void Handle(InteractionResponseType responseType);
    }
}

