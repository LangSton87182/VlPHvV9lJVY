// 代码生成时间: 2025-09-21 08:19:39
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;

namespace XssProtectionApp
{
    /// <summary>
    /// 一个服务类用于防护XSS攻击。
    /// </summary>
    public class XssProtectionService
    {
        /// <summary>
        /// 清理输入，防止XSS攻击。
        /// </summary>
        /// <param name="input">需要清理的输入</param>
        /// <returns>清理后的输入</returns>
        public HtmlString SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                // 如果输入为空或空白字符串，返回空的HtmlString
                return HtmlString.Empty;
            }

            // 清理输入以防止XSS攻击
            return CleanInput(input);
        }

        /// <summary>
        /// 清理输入字符串的具体实现。
        /// </summary>
        /// <param name="input">需要清理的输入</param>
        /// <returns>清理后的输入字符串</returns>
        private HtmlString CleanInput(string input)
        {
            // 使用正则表达式移除所有潜在的XSS攻击代码
            // 这里仅作为示例，实际应用中可能需要更复杂的规则
            input = Regex.Replace(input, @"<script.*?>.*?</script>@", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            input = Regex.Replace(input, @"<.*?javascript.*?>.*?</.*?>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            input = Regex.Replace(input, @"on.*?=", string.Empty);
            input = Regex.Replace(input, @"=\s*".*?script.*?".*?", string.Empty);

            // 返回清理后的字符串
            return new HtmlString(input);
        }
    }
}