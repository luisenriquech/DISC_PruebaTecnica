using FluentValidation.Results;

namespace DISC_PruebaTecnica.DTO.General
{
    public class SuccessResult
    {
        #region Propiedades

        public int Count { get; set; }       
        public object Results { get; set; }
        public List<ValidationFailure> Validations { get; set; }
        public bool Error { get; set; }
        public string MsgResponse { get; set; }

        #endregion

        public SuccessResult()
        {
        }


        public SuccessResult(int count, object res)
        {
            Count = count;
            Results = res;
        }
        public SuccessResult(bool error, object res)
        {
            Error = error;
            Results = res;
        }

        public SuccessResult(bool error, int count, object res)
        {
            Count = count;
            Error = error;
            Results = res;
        }

        public SuccessResult(object res)
        {
            Results = res;
        }
        public SuccessResult(object res, string mesResponse)
        {
            Results = res;
            MsgResponse = mesResponse;
        }

    

        public SuccessResult(int count, string mesResponse)
        {
            Count = count;
            MsgResponse = mesResponse;
        }

        public SuccessResult(string mesResponse)
        {
            MsgResponse = mesResponse;
        }
        public SuccessResult(bool error, List<ValidationFailure> Validator)
        {
            Error = error;
            Validations = Validator;
        }
        public SuccessResult(bool error, List<ValidationFailure> Validator, string mesResponse)
        {
            Error = error;
            Validations = Validator;
            MsgResponse = mesResponse;
        }
        public SuccessResult(bool error, int count, List<ValidationFailure> Validator, string mesResponse)
        {
            Error = error;
            Count = count;
            Validations = Validator;
            MsgResponse = mesResponse;
        }

        public SuccessResult(bool error, string msgResponse)
        {
            Error = error;
            MsgResponse = msgResponse;
        }
        public SuccessResult(bool error, string msgResponse, object res)
        {
            Error = error;
            MsgResponse = msgResponse;
            Results = res;
        }
    }
}
