namespace DISC_PruebaTecnica.Configuration
{
    public interface IPresenter<ResponseType> : IOutPutPort<ResponseType>
    {
        public ResponseType Content { get; }
    }
}
