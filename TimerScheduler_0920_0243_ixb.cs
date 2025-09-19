// 代码生成时间: 2025-09-20 02:43:24
// TimerScheduler.cs
// This class serves as a simple timer scheduler that can execute tasks on a schedule.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinApp
{
    public class TimerScheduler
# TODO: 优化性能
    {
        // List to hold scheduled tasks
        private readonly List<(Timer Timer, TimeSpan Interval, Action Task)> tasks = new List<(Timer, TimeSpan, Action)>();

        // Method to schedule a new task
        public void ScheduleTask(TimeSpan interval, Action task)
# 扩展功能模块
        {
            // Create a new timer
            Timer timer = new Timer(_ =>
            {
                try
                {
                    task();
                }
                catch (Exception ex)
                {
                    // Log error or handle exception as needed
                    Console.WriteLine($"Error executing task: {ex.Message}");
                }
            }, null, interval, interval);

            // Add the timer and its details to the list
            tasks.Add((timer, interval, task));
        }

        // Method to cancel all scheduled tasks
        public void CancelAllTasks()
# TODO: 优化性能
        {
            foreach (var (timer, _, _) in tasks)
            {
                timer.Dispose();
            }
# 增强安全性

            tasks.Clear();
        }

        // Method to cancel a specific task
# 增强安全性
        public void CancelTask(Action task)
# NOTE: 重要实现细节
        {
            for (int i = tasks.Count - 1; i >= 0; i--)
            {
# 添加错误处理
                if (tasks[i].Task == task)
# 改进用户体验
                {
                    tasks[i].Timer.Dispose();
# 添加错误处理
                    tasks.RemoveAt(i);
                    break;
                }
            }
        }

        // Destructor to ensure all timers are disposed when the scheduler is no longer in use
        ~TimerScheduler()
        {
# 扩展功能模块
            CancelAllTasks();
        }
    }
}
