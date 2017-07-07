using System;

namespace App.Core.Utils
{
    static class Constants
    {
        // API ENDPOINT
        private const String API_ENDPOINT_BASE = "http://jsonplaceholder.typicode.com";

        public const String API_ENDPOINT_POSTS = API_ENDPOINT_BASE + "/posts";
        public const String API_ENDPOINT_POST = API_ENDPOINT_POSTS + "/{0}";

    }
}
