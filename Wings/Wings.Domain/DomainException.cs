using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wings.Domain
{
    public class DomainException : Exception
    {
        public DomainException() : base() { }
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
        public DomainException(string format, params object[] args) : base(string.Format(format, args)) { }
        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
