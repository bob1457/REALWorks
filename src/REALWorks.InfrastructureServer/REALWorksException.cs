using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.InfrastructureServer
{
    public class REALWorksException: Exception
    {
        public string Code { get; }

        public REALWorksException()
        {
        }

        public REALWorksException(string code)
        {
            Code = code;
        }

        public REALWorksException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public REALWorksException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public REALWorksException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public REALWorksException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
