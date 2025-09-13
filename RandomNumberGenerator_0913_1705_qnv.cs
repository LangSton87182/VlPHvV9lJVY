// 代码生成时间: 2025-09-13 17:05:22
using System;
using Xamarin.Forms;

// 定义一个类，用于生成随机数
public class RandomNumberGenerator : ContentPage
{
    private readonly Random _random;
    private Label _resultLabel;

    public RandomNumberGenerator()
    {
        // 初始化随机数生成器
        _random = new Random();

        // 定义页面布局和控件
        Title = "Random Number Generator";
        Content = new StackLayout
        {
            Children =
            {
                new Label
                {
                    Text = "Enter the range of numbers"
                },
                new Entry { AutomationId = "inputEntry" },
                _resultLabel = new Label
                {
                    Text = "Tap the button to generate a random number."
                },
                new Button
                {
                    Text = "Generate",
                    Command = new Command(async () => await GenerateRandomNumberAsync())
                }
            }
        };
    }

    // 异步方法，用于生成随机数
    private async Task GenerateRandomNumberAsync()
    {
        try
        {
            // 获取用户输入的范围数值
            string input = ((App)Application.Current).InputEntry.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                // 如果输入为空，则提示用户
                await DisplayAlert("Error", "Please enter the range of numbers.", "OK");
                return;
            }

            // 尝试将输入转换为整数范围
            if (!int.TryParse(input, out int range) || range <= 0)
            {
                await DisplayAlert("Error", "Invalid input. Please enter a positive integer.", "OK");
                return;
            }

            // 生成随机数并更新标签显示结果
            int randomNumber = _random.Next(range);
            _resultLabel.Text = $"Random number: {randomNumber}";
        }
        catch (Exception ex)
        {
            // 处理可能的异常，并显示错误信息
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
