using App.Core.Exceptions;
using App.Core.Models;
using App.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.Core.Services
{
    class ApiService : IApiService
    {
        private async Task<String> DownloadData(String uri)
        {
            var response = String.Empty;
            HttpResponseMessage httpResponseMessage;
            HttpClient httpClient = new HttpClient();

            if (!NetworkHelper.CheckConnectivity())
            {
                throw new NetworkException("NO_NET");
            }

            try
            {
                httpResponseMessage = await httpClient.GetAsync(new Uri(uri));
                response = await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("BAD_GET_URI");
            }

            switch (httpResponseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        // 200
                        Debug.WriteLine("[ApiService.DownloadData]\t" + "HttpStatusCode 200 - OK");
                        break;
                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        // 400
                        Debug.WriteLine("[ApiService.DownloadData]\t" + "HttpStatusCode 400 - BadRequest");
                        throw new ApiException(response);
                    }
                case System.Net.HttpStatusCode.Unauthorized:
                    {
                        // 401
                        Debug.WriteLine("[ApiService.DownloadData]\t" + "HttpStatusCode 401 - Unauthorized");
                        throw new ApiException(response);
                    }
                case System.Net.HttpStatusCode.NotFound:
                    {
                        // 404
                        Debug.WriteLine("[ApiService.DownloadData]\t" + "HttpStatusCode 404 - NotFound");
                        throw new ApiException(response);
                    }
                case System.Net.HttpStatusCode.InternalServerError:
                    {
                        // 500
                        Debug.WriteLine("[ApiService.DownloadData]\t" + "HttpStatusCode 500 - InternalServerError");
                        throw new ApiException(response);
                    }
            }

            return response;
        }

        public async void GetPosts(Action<List<Post>, Exception> callback)
        {
            Exception exception = null;
            List<Post> results = new List<Post>();
            String uri = Constants.API_ENDPOINT_POSTS;
            var response = String.Empty;

            try
            {
                response = await DownloadData(uri);

                List<Post> responseDeserialized = JsonConvert.DeserializeObject<List<Post>>(response);
                //var responseDeserializedRestricted = from item in responseDeserialized.Result
                //                                     select item;
                foreach (var s in responseDeserialized)
                {
                    results.Add(s);
                }
            }
            catch (NetworkException ne)
            {
                exception = ne;
            }
            catch (ArgumentNullException ane)
            {
                exception = ane;
            }
            catch (ApiException ae)
            {
                exception = ae;
            }

            Debug.WriteLine("[URI]\t{0}\n[RESPONSE]{1}\n\n", uri, response);

            callback(results, exception);
        }

        public async void GetPost(Action<Post, Exception> callback, string id_post)
        {
            Exception exception = null;
            Post results = new Post();
            String uri = String.Format(Constants.API_ENDPOINT_POST, id_post);
            var response = String.Empty;

            try
            {
                response = await DownloadData(uri);

                Post responseDeserialized = JsonConvert.DeserializeObject<Post>(response);
                results = responseDeserialized;
            }
            catch (NetworkException ne)
            {
                exception = ne;
            }
            catch (ArgumentNullException ane)
            {
                exception = ane;
            }
            catch (ApiException ae)
            {
                exception = ae;
            }

            Debug.WriteLine("[URI]\t{0}\n[RESPONSE]{1}\n\n", uri, response);

            callback(results, exception);
        }
    }
}
