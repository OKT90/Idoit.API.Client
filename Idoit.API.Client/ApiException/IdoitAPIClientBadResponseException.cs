using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Idoit.API.Client.CMDB.Category.Request;

namespace Idoit.API.Client.ApiException
{
   public class IdoitAPIClientBadResponseException : Exception
    {
        // Constructors
        public IdoitAPIClientBadResponseException(string message) : base(message)
        {
        }
        // Ensure Exception is Serializable
        protected IdoitAPIClientBadResponseException(SerializationInfo info,
            StreamingContext text) : base(info, text)
        {
        }
    }
}
