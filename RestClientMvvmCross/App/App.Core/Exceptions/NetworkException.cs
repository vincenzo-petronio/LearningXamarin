using System;

namespace App.Core.Exceptions
{
    class NetworkException : Exception
    {
        public string Msg { get; set; }

        public NetworkException(string msg)
            : base(msg)
        {
            this.Msg = msg;
        }
    }
}
