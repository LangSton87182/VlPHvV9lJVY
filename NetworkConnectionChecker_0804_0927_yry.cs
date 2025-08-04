// 代码生成时间: 2025-08-04 09:27:09
using System;
using Xamarin.Essentials;

namespace NetworkStatusChecker
{
    public class NetworkConnectionChecker
    {
        // Check the current network connection status
        public NetworkAccessStatus CheckConnectionStatus()
        {
            try
            {
                return Connectivity.NetworkAccess;
            }
            catch (Exception ex)
            {
                // Log the exception and handle accordingly
                Console.WriteLine($"An error occurred while checking the connection status: {ex.Message}");
                return NetworkAccessStatus.Unknown;
            }
        }

        // Event handler for connectivity changes
        public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

        // Subscribe to the ConnectivityChanged event
        public void SubscribeToConnectivityChanges()
        {
            Connectivity.ConnectivityChanged += OnConnectivityChanged;
        }

        // Unsubscribe from the ConnectivityChanged event
        public void UnsubscribeFromConnectivityChanges()
        {
            Connectivity.ConnectivityChanged -= OnConnectivityChanged;
        }

        // Handle connectivity changes
        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(sender, e);
        }
    }

    // Define an enum for network access status
    public enum NetworkAccessStatus
    {
        None,
        Local,
        Internet,
        Unknown
    }

    // Define an event args class for connectivity change events
    public class ConnectivityChangedEventArgs : EventArgs
    {
        public NetworkAccessStatus NewStatus { get; private set; }

        public ConnectivityChangedEventArgs(NetworkAccessStatus newStatus)
        {
            NewStatus = newStatus;
        }
    }
}
