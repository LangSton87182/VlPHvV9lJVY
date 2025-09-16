// 代码生成时间: 2025-09-17 00:55:06
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinHttpService
{
    /// <summary>
    /// A service to handle HTTP requests using Xamarin.Essentials and HttpClient.
    /// </summary>
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the HttpService class.
        /// </summary>
        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Sends a GET request to the specified URL and returns the response as a string.
        /// </summary>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <returns>A task that represents the asynchronous operation, returning the response as a string.</returns>
        public async Task<string> GetStringAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Handle any exceptions that occur during the request.
                throw new Exception("Error while sending GET request: " + e.Message);
            }
        }

        /// <summary>
        /// Sends a POST request to the specified URL with the provided content and returns the response as a string.
        /// </summary>
        /// <param name="url">The URL to send the POST request to.</param>
        /// <param name="content">The content to send with the POST request.</param>
        /// <returns>A task that represents the asynchronous operation, returning the response as a string.</returns>
        public async Task<string> PostStringAsync(string url, string content)
        {
            try
            {
                var response = await _httpClient.PostAsync(url, new StringContent(content));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Handle any exceptions that occur during the request.
                throw new Exception("Error while sending POST request: " + e.Message);
            }
        }

        // Additional methods for PUT, DELETE, etc., can be added here to extend the functionality.
    }
}
