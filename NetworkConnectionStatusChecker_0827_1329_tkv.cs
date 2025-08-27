// 代码生成时间: 2025-08-27 13:29:41
using System;
using System.Net.NetworkInformation;
using Xamarin.Forms;

namespace XamarinNetworkConnectionChecker
{
    /// <summary>
    /// A class to check network connectivity status.
    /// </summary>
    public class NetworkConnectionStatusChecker
    {
        /// <summary>
        /// Checks if the device has an active internet connection.
        /// </summary>
        /// <returns>Boolean indicating if the network is connected.</returns>
        public bool IsConnected()
        {
            try
            {
                // Check if there are any network interfaces that are connected
                return NetworkInterface.GetIsNetworkAvailable() && 
                       IsConnectedToInternet();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                DependencyService.Get<ILogger>().Log(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks if the device is connected to the internet.
        /// </summary>
        /// <returns>Boolean indicating if the device is connected to the internet.</returns>
        private bool IsConnectedToInternet()
        {
            try
            {
                // Use HttpWebRequest to try to connect to a known online service
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.google.com");
                httpWebRequest.Method = "HEAD";
                httpWebRequest.Timeout = 3000; // 3 seconds timeout
                using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    return httpResponse.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                // If there is a web exception, the device is not connected to the internet
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                DependencyService.Get<ILogger>().Log(ex.Message);
                return false;
            }
        }
    }
}
