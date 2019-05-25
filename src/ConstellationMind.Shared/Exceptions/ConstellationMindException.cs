using System;

namespace ConstellationMind.Shared.Exceptions
{
    public class ConstellationMindException : Exception
    {
        public string Code { get; }

        public ConstellationMindException() { }

        public ConstellationMindException(string code) 
            => Code = code;

        public ConstellationMindException(string message, params object[] args) 
            : this(string.Empty, message, args) { }

        public ConstellationMindException(string code, string message, params object[] args) 
            : this(null, code, message, args) { }

        public ConstellationMindException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args) { }

        public ConstellationMindException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) 
                => Code = code;
    }
}
