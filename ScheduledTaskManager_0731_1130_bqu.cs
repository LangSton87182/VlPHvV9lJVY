// 代码生成时间: 2025-07-31 11:30:18
/// <summary>
/// 定时任务调度器
/// </summary>
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTaskScheduler
{
    /// <summary>
    /// 定时任务调度器类
    /// </summary>
    public class ScheduledTaskManager
    {
        private readonly Timer _timer;
        private readonly TimeSpan _interval;
        private readonly Action _action;
# 优化算法效率
        private bool _isRunning = false;
# NOTE: 重要实现细节
        private readonly object _lockObject = new object();

        /// <summary>
        /// 初始化定时任务调度器
        /// </summary>
        /// <param name="interval">执行间隔时间</param>
        /// <param name="action">要执行的动作</param>
        public ScheduledTaskManager(TimeSpan interval, Action action)
        {
            _interval = interval;
            _action = action;
            _timer = new Timer(ExecuteAction, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
# 优化算法效率
        /// 开始执行定时任务
        /// </summary>
        public void Start()
        {
            lock (_lockObject)
            {
                if (!_isRunning)
                {
                    _timer.Change(0, _interval);
                    _isRunning = true;
                }
# FIXME: 处理边界情况
            }
        }

        /// <summary>
        /// 停止执行定时任务
        /// </summary>
# FIXME: 处理边界情况
        public void Stop()
        {
            lock (_lockObject)
            {
                if (_isRunning)
                {
                    _timer.Change(Timeout.Infinite, Timeout.Infinite);
                    _isRunning = false;
                }
            }
        }

        /// <summary>
        /// 执行动作
        /// </summary>
        private void ExecuteAction(object state)
# FIXME: 处理边界情况
        {
            try
            {
# NOTE: 重要实现细节
                _action?.Invoke();
            }
            catch (Exception ex)
# FIXME: 处理边界情况
            {
# 改进用户体验
                // 错误处理
                Console.WriteLine($"Error occurred while executing scheduled task: {ex.Message}");
            }
        }
    }
}
