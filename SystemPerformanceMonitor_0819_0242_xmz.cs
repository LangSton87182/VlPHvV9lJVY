// 代码生成时间: 2025-08-19 02:42:57
using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SystemPerformanceMonitorApp
{
    // 系统性能监控工具
    public class SystemPerformanceMonitor
    {
        public async Task MonitorPerformance()
        {
            try
            {
                // 获取设备信息
                var deviceInfo = DeviceInfo;
                Console.WriteLine($"设备信息：
  制造商：{deviceInfo.Manufacturer}
  型号：{deviceInfo.Model}
  版本：{deviceInfo.Version}");

                // 获取系统性能信息
                var cpuUsage = await DeviceInfo.GetCpuUsageAsync();
                Console.WriteLine($"CPU使用率：{cpuUsage}%");

                var memoryUsage = await DeviceInfo.GetMemoryUsageAsync();
                Console.WriteLine($"内存使用率：{memoryUsage.UsagePercentage}%");

                var batteryInfo = await Battery.GetBatteryInfoAsync();
                Console.WriteLine($"电池电量：{batteryInfo.ChargeLevel}%");

                // 获取网络状态
                var connectivity = Connectivity.NetworkAccess;
                if(connectivity == NetworkAccess.Internet)
                {
                    Console.WriteLine("网络状态：已连接到互联网");
                }
                else
                {
                    Console.WriteLine("网络状态：无网络连接");
                }

                // 获取位置信息
                var location = await Geolocation.GetLastKnownLocationAsync();
                if(location != null)
                {
                    Console.WriteLine($"最后位置：纬度 {location.Latitude}, 经度 {location.Longitude}");
                }
                else
                {
                    Console.WriteLine("无法获取位置信息");
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"监控过程中发生错误：{ex.Message}");
            }
        }
    }
}
