// 代码生成时间: 2025-08-06 21:48:25
// <summary>
// Represents a Network Status Checker class in C# using Xamarin.Forms
// </summary>
using System;
using Xamarin.Essentials;

namespace XamarinNetworkStatus
{
    public class NetworkStatusChecker
    {
        // <summary>
        // Checks the current network connectivity status
        // </summary>
        // <returns>
        // True if connected, False if not
        // </returns>
        public bool CheckNetworkConnectivity()
        {
            try
            {
                // Obtain the current network connectivity status
                var connectivity = Connectivity.NetworkAccess;

                // Check if we have internet access
                if (connectivity == NetworkAccess.Internet)
                {
                    Console.WriteLine("Connected to the internet.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Not connected to the internet.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the check
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        // <summary>
        // Registers a listener for network connectivity changes
        // </summary>
        public void RegisterNetworkChangeListener(Action<bool> callback)
        {
            try
            {
                // Subscribe to the ConnectivityChanged event
                Xamarin.Essentials.Connectivity.ConnectivityChanged += (sender, e) =>
                {
                    callback(CheckNetworkConnectivity());
                };
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during registration
                Console.WriteLine($"Failed to register network change listener: {ex.Message}");
            }
        }
    }
}
