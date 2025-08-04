// 代码生成时间: 2025-08-05 01:19:02
using System;
using System.Diagnostics;
using Xamarin.Forms; // 导入Xamarin.Forms命名空间

namespace SystemMonitorApp
{
    // 系统性能监控工具类
    public class SystemPerformanceMonitor
    {
        public async Task MonitorPerformanceAsync()
        {
            try
            {
                // 获取系统信息
                if (DeviceInfo.Idiom == DeviceIdiom.Phone)
                {
                    // 手机设备，显示电池和网络状态
                    await DisplayBatteryStatusAsync();
                    await DisplayNetworkStatusAsync();
                }
                else
                {
                    // 非手机设备，显示CPU和内存使用情况
                    await DisplayCpuUsageAsync();
                    await DisplayMemoryUsageAsync();
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Debug.WriteLine($"系统性能监控错误：{ex.Message}");
            }
        }

        // 显示电池状态
        private async Task DisplayBatteryStatusAsync()
        {
            // 获取电池信息
            var batteryInfo = BatteryInfo.Instance;
            // 显示电池状态
            await DisplayAlert("电池状态", batteryInfo.Status.ToString(), "确定");
        }

        // 显示网络状态
        private async Task DisplayNetworkStatusAsync()
        {
            // 获取网络信息
            var networkInfo = Connectivity.NetworkAccess == NetworkAccess.Internet ? "已连接" : "未连接";
            // 显示网络状态
            await DisplayAlert("网络状态", networkInfo, "确定");
        }

        // 显示CPU使用情况
        private async Task DisplayCpuUsageAsync()
        {
            // 获取CPU使用率
            var cpuUsage = Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds;
            // 显示CPU使用情况
            await DisplayAlert("CPU使用情况", $"CPU使用率：{cpuUsage}%", "确定");
        }

        // 显示内存使用情况
        private async Task DisplayMemoryUsageAsync()
        {
            // 获取内存信息
            var memInfo = new PerformanceCounter("Process", "Working Set", "_Total");
            var memUsage = memInfo.NextValue();
            // 显示内存使用情况
            await DisplayAlert("内存使用情况", $"内存使用率：{memUsage}%", "确定");
        }
    }
}
