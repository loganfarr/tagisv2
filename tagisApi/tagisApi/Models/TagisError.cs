using System;

namespace tagisApi.Models
{
    public class TagisError
    {
        public string ErrorMessage { get; }
        public int ErrorCode { get; }
        public string Error { get; }
        public TagisError(int errorCode, string errorMessage, string error)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Error = error;
        }
    }
}