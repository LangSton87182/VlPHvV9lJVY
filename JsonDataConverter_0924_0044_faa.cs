// 代码生成时间: 2025-09-24 00:44:26
using System;
using Newtonsoft.Json;

// JsonDataConverter.cs
// 该类负责将JSON数据格式转换为C#对象

public static class JsonDataConverter
{
    // 将JSON字符串转换为C#对象
    //typeparam T 目标对象类型
    //param json JSON字符串
    //returns 转换后的对象
    public static T ConvertFromJson<T>(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            throw new ArgumentException("JSON string cannot be null or empty.", nameof(json));
        }

        try
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
        catch (JsonException e)
        {
            // 处理JSON解析异常
            throw new InvalidOperationException("Failed to deserialize JSON.", e);
        }
    }

    // 将C#对象转换为JSON字符串
    //typeparam T 源对象类型
    //param obj 源对象
    //returns JSON字符串
    public static string ConvertToJson<T>(T obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Object cannot be null.");
        }

        try
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }
        catch (JsonException e)
        {
            // 处理JSON序列化异常
            throw new InvalidOperationException("Failed to serialize object to JSON.", e);
        }
    }
}
