using System;

namespace App.Core.Exceptions
{
    class ApiException : Exception
    {
        public string Msg { get; set; }

        public ApiException(string msg)
            : base(msg)
        {
            this.Msg = msg;
        }
    }
}
