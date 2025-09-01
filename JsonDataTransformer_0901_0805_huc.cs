// 代码生成时间: 2025-09-01 08:05:25
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace JsonDataTransformerApp
{
    // JsonDataTransformer类用于将JSON数据格式进行转换
    public class JsonDataTransformer
    {
        private readonly JsonSerializerSettings _settings;

        public JsonDataTransformer()
        {
            // 初始化JsonSerializerSettings，用于格式化输出和处理异常
            _settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Error = (sender, args) =>
                {
                    // 捕获序列化错误并记录
                    Console.WriteLine("Error: " + args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }
            };
        }

        // 将JSON字符串转换为C#对象
        public T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, _settings);
            }
            catch (Exception ex)
            {
                // 处理反序列化错误
                Console.WriteLine($"Deserialization error: {ex.Message}");
                throw;
            }
        }

        // 将C#对象转换为JSON字符串
        public string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, _settings);
            }
            catch (Exception ex)
            {
                // 处理序列化错误
                Console.WriteLine($"Serialization error: {ex.Message}");
                throw;
            }
        }

        // 将JSON文件转换为C#对象
        public T DeserializeFromFile<T>(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath, Encoding.UTF8);
                return Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File read error: {ex.Message}");
                throw;
            }
        }

        // 将C#对象转换为JSON并保存到文件
        public void SerializeToFile<T>(T obj, string filePath)
        {
            try
            {
                string json = Serialize<T>(obj);
                File.WriteAllText(filePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File write error: {ex.Message}");
                throw;
            }
        }
    }
}
