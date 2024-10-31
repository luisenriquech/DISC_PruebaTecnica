using DISC_PruebaTecnica.DTO.General;

namespace DISC_PruebaTecnica.Configuration
{
    public class GenericPresenter : IPresenter<SuccessResult>
    {
        public SuccessResult Content { get; set; }

        public void Handle(SuccessResult responseType)
        {
            Content = responseType;
        }
    }
}
