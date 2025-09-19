// 代码生成时间: 2025-09-19 18:25:59
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

// 网页内容抓取工具
public class WebContentGrabber
{
    private readonly HttpClient _httpClient;

    // 构造器，初始化HttpClient实例
    public WebContentGrabber()
    {
        _httpClient = new HttpClient();
    }

    // 异步方法，用于获取网页的HTML内容
    public async Task<string> FetchWebContentAsync(string url)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmlContent = await response.Content.ReadAsStringAsync();
            return htmlContent; // 返回网页的HTML内容
        }
        catch (HttpRequestException e)
        {
            // 错误处理，日志记录等操作
            Console.WriteLine("Error fetching web content: " + e.Message);
            throw; // 重新抛出异常，以便调用者处理
        }
    }

    // 异步方法，用于从HTML中提取文本内容
    public async Task<string> ExtractTextContentAsync(string htmlContent)
    {
        try
        {
            // 使用正则表达式移除HTML标签，仅保留文本内容
            string textContent = Regex.Replace(htmlContent, "<[^>]*>.*?|<[^>]*>", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return textContent.Trim(); // 返回清理后的文本内容
        }
        catch (Exception e)
        {
            // 错误处理，日志记录等操作
            Console.WriteLine("Error extracting text content: " + e.Message);
            throw; // 重新抛出异常，以便调用者处理
        }
    }
}
