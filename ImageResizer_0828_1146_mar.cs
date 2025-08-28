// 代码生成时间: 2025-08-28 11:46:55
// ImageResizer.cs
// 这是一个用于批量调整图片尺寸的工具类。

using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinApp
{
    public class ImageResizer
    {
        private readonly string sourceFolder;
        private readonly string destinationFolder;
        private readonly SKEncodedImageFormat imageFormat;
        private readonly int targetWidth;
# 添加错误处理
        private readonly int targetHeight;

        // 构造函数
        public ImageResizer(string sourceFolder, string destinationFolder, SKEncodedImageFormat imageFormat, int targetWidth, int targetHeight)
# 增强安全性
        {
            this.sourceFolder = sourceFolder;
            this.destinationFolder = destinationFolder;
            this.imageFormat = imageFormat;
# 添加错误处理
            this.targetWidth = targetWidth;
            this.targetHeight = targetHeight;
        }

        // 调整图片尺寸的方法
        public async Task ResizeImagesAsync()
# TODO: 优化性能
        {
# FIXME: 处理边界情况
            try
# 增强安全性
            {
                // 获取源文件夹中所有图片文件
                var images = Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories)
# 改进用户体验
                    .Where(f => f.EndsWith(".png") || f.EndsWith(".jpg") || f.EndsWith(".jpeg"));

                foreach (var imagePath in images)
# 扩展功能模块
                {
                    using var image = SKBitmap.Decode(File.ReadAllBytes(imagePath));
                    if (image == null)
# NOTE: 重要实现细节
                    {
                        Console.WriteLine($"Image {imagePath} cannot be decoded.");
                        continue;
                    }

                    // 创建新的尺寸
# FIXME: 处理边界情况
                    int width = targetWidth;
                    int height = targetHeight;

                    // 调整图片尺寸
# 添加错误处理
                    using var resizedImage = new SKBitmap(width, height);
                    SKImageInfo info = new SKImageInfo(width, height);
                    using var canvas = new SKCanvas(resizedImage);
                    canvas.Clear(SKColors.Transparent);
                    canvas.DrawBitmap(image, new SKRect(0, 0, width, height), SKPaintFilterQuality.High);

                    // 保存调整后的图片
                    var filename = Path.GetFileName(imagePath);
                    var destinationPath = Path.Combine(destinationFolder, filename);
                    using var data = new SKDynamicPicture();
                    data.EncodeBitmap(resizedImage, imageFormat);
                    File.WriteAllBytes(destinationPath, data.Data.ToArray());
                }
# 扩展功能模块
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resizing images: {ex.Message}");
            }
# TODO: 优化性能
        }
    }
}
