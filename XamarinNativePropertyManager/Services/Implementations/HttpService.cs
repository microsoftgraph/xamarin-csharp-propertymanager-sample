/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinNativePropertyManager.Extensions;

namespace XamarinNativePropertyManager.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public Uri Resource { get; set; }

        public HttpRequestHeaders GetRequestHeaders()
        {
            return _httpClient.DefaultRequestHeaders;
        }

        public Task<T> GetAsync<T>(string resource)
        {
            return SendAsync<T>(resource, HttpMethod.Get);
        }

        public Task<T> PostAsync<T>(string resource, object data)
        {
            return SendAsync<T>(resource, HttpMethod.Post, data);
        }

        public Task<T> PostAsync<T>(string resource, Stream stream, string contentType)
        {
            return SendAsync<T>(resource, HttpMethod.Post, stream, contentType);
        }

        public Task<T> PutAsync<T>(string resource, object data)
        {
            return SendAsync<T>(resource, HttpMethod.Put, data);
        }

        public Task<T> PutAsync<T>(string resource, Stream stream, string contentType)
        {
            return SendAsync<T>(resource, HttpMethod.Put, stream, contentType);
        }

        public Task<T> PatchAsync<T>(string resource, object data)
        {
            return SendAsync<T>(resource, HttpMethod.Patch, data);
        }

        public Task<T> PatchAsync<T>(string resource, Stream stream, string contentType)
        {
            return SendAsync<T>(resource, HttpMethod.Patch, stream, contentType);
        }

        public async Task<T> SendAsync<T>(string resource, HttpMethod httpMethod, object data)
        {
            var str = JsonConvert.SerializeObject(data, Constants.JsonSerializerSettings);
            using (var stream = str.GetStream())
            {
                return await SendAsync<T>(resource, httpMethod, 
                    stream, Constants.JsonContentType);
            }
        }

        public async Task<T> SendAsync<T>(string resource, HttpMethod httpMethod, Stream stream = null, string contentType = null)
        {
            // Create request URI.
            var requestUri = new Uri(Resource.AbsoluteUri + resource);

            // Get response.
            HttpResponseMessage response = null;
            switch (httpMethod)
            {
                case HttpMethod.Get:
                {
                    response = await _httpClient.GetAsync(requestUri);
                }
                    break;
                case HttpMethod.Post:
                case HttpMethod.Put:
                case HttpMethod.Patch:
                {
                    // Create content.
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                    switch (httpMethod)
                    {
                        case HttpMethod.Post:
                        {
                            response = await _httpClient.PostAsync(requestUri, streamContent);
                        }
                            break;
                        case HttpMethod.Put:
                        {
                            response = await _httpClient.PutAsync(requestUri, streamContent);
                        }
                            break;
                        case HttpMethod.Patch:
                        {
                            response = await _httpClient.PatchAsync(requestUri, streamContent);
                        }
                            break;
                    }
                }
                    break;
            }

            if (response == null)
            {
                throw new NotImplementedException();
            }

            // Check response.
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new HttpRequestException("Unauthorized");
                }
                throw new HttpRequestException(response.ReasonPhrase);
            }

            // Parse the response.
            var result = JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}
