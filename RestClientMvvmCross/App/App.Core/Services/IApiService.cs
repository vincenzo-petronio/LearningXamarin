using App.Core.Models;
using System;
using System.Collections.Generic;

namespace App.Core.Services
{
    interface IApiService
    {
        /// <summary>
        /// /posts
        /// </summary>
        /// <param name="callback"></param>
        void GetPosts(Action<List<Post>, Exception> callback);

        /// <summary>
        /// /posts/id
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="id_post"></param>
        void GetPost(Action<Post, Exception> callback, String id_post);
    }
}
