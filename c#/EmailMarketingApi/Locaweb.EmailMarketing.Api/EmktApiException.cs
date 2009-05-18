using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locaweb.EmailMarketing.Api
{
    public class EmktApiException: Exception
    {
        public EmktApiException() : base() { }
        public EmktApiException(string message) : base(message) { }
    }
}
