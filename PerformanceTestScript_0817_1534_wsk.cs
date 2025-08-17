// 代码生成时间: 2025-08-17 15:34:33
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinPerformanceTest;
{
    // 性能测试脚本类
    public class PerformanceTestScript
    {
        private readonly int testIterations = 100;
        private readonly Stopwatch stopwatch;

        // 构造函数
        public PerformanceTestScript()
        {
            stopwatch = new Stopwatch();
        }

        // 运行性能测试
        public void RunTest(Action action)
        {
            try
            {
                for (int i = 0; i < testIterations; i++)
                {
                    stopwatch.Restart();
                    action?.Invoke(); // 执行传入的动作
                    stopwatch.Stop();
                }

                // 计算平均运行时间
                double averageTime = stopwatch.Elapsed.TotalMilliseconds / testIterations;

                // 输出测试结果
                Console.WriteLine($"Average execution time: {averageTime} ms");
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error during performance test: {ex.Message}");
            }
        }

        // 异步运行性能测试
        public async Task RunTestAsync(Func<Task> action)
        {
            try
            {
                for (int i = 0; i < testIterations; i++)
                {
                    stopwatch.Restart();
                    await action?.Invoke(); // 异步执行传入的函数
                    stopwatch.Stop();
                }

                // 计算平均运行时间
                double averageTime = stopwatch.Elapsed.TotalMilliseconds / testIterations;

                // 输出测试结果
                Console.WriteLine($"Average execution time: {averageTime} ms");
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error during performance test: {ex.Message}");
            }
        }
    }
}
