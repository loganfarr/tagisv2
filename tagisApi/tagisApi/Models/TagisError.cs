using System;

namespace tagisApi.Models
{
    public class TagisError
    {
        private string _errorMessage;
        private string _errorCode;

        public TagisError AddError(string code, string message)
        {
            Console.WriteLine("An error occurred with TAGIS. Code: " + code + ". Message: " + message);
            
            _errorMessage = message;
            _errorCode = code;
            return this;
        }
    }
}