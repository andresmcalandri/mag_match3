using System;

namespace MAG.Results
{
    public readonly struct Error 
    {
        public string Message { get; }
        public Exception? InnerException { get; }
        public Error(string message = "", Exception? innerException = null)
        {
            Message = message;
            InnerException = innerException;
        }
    }
}