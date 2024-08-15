using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Url.Domain.Errors
{
    public sealed class NotValidDataException : Exception
    {
        public NotValidDataException(string message) : base(message)
        {
        }
    }
}
