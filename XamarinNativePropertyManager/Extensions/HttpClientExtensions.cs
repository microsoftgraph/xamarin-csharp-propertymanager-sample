using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinNativePropertyManager.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PatchAsync<T>(this HttpClient client,
            Uri requestUri, T value) where T : HttpContent
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = value
            };
            return client.SendAsync(request);
        }
    }
}
