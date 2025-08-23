// 代码生成时间: 2025-08-24 04:31:02
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XamarinXssProtection
{
    /// <summary>
    /// Service responsible for protecting against XSS (Cross-Site Scripting) attacks.
    /// </summary>
    public class XssProtectionService
    {
        /// <summary>
        /// Sanitizes the input to prevent XSS attacks.
        /// </summary>
        /// <param name="input">The user input to sanitize.</param>
        /// <returns>A sanitized version of the input.</returns>
        public string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            // Remove script tags
            input = Regex.Replace(input, "<(script|iframe|embed|object)[^>]*>.*?<\/\1>|<(?=(<[a-z][\s\S]*?\shref=[^>]*|<[^>]*?\stype=['"]?javascript[^>]*|<[^>]*?\ssrc=(?=['"]?javascript:)[^>]*|<[^>]*?\sbackground=[^>]*|<[^>]*?\saction=[^>]*|<[^>]*?\sformaction=[^>]*)>)", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

            // Remove inline event handlers
            input = Regex.Replace(input, "(onerror|onload|onerror|onabort|onblur|onchange|onfocus|onreset|onselect|onsubmit|onunload)=[^>]*", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            // Remove JavaScript: URLs
            input = Regex.Replace(input, "javascript:.*?(\s|$)", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            // Remove VBScript: URLs
            input = Regex.Replace(input, "vbscript:.*?(\s|$)", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            // Remove any other non-alphanumeric characters or strings that could potentially be dangerous
            input = Regex.Replace(input, "[^a-zA-Z0-9\s]", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            return input;
        }
    }
}
