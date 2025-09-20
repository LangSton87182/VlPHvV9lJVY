// 代码生成时间: 2025-09-20 12:51:51
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileManager
{
    public class FolderOrganizer
    {
        // 用于存放文件的默认目录
        private readonly string _defaultDirectory = "./OrganizedFiles";

        public FolderOrganizer()
        {
            // 确保默认目录存在
            Directory.CreateDirectory(_defaultDirectory);
        }

        // 主方法，整理指定文件夹
        public void OrganizeFolder(string sourcePath)
        {
            try
            {
                // 检查源路径是否存在
                if (!Directory.Exists(sourcePath))
                {
                    throw new DirectoryNotFoundException($"Source directory not found: {sourcePath}");
                }

                // 获取所有文件
                var files = Directory.GetFiles(sourcePath);

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    var extension = fileInfo.Extension;

                    // 根据文件扩展名确定目标文件夹
                    var targetFolder = Path.Combine(_defaultDirectory, extension.TrimStart('.'));

                    // 创建目标文件夹
                    Directory.CreateDirectory(targetFolder);

                    // 移动文件到目标文件夹
                    File.Move(file, Path.Combine(targetFolder, fileInfo.Name));
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // 辅助方法，用于清理文件名中的非法字符
        private string SanitizeFileName(string fileName)
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 使用默认文件夹或用户指定的文件夹路径
            var organizer = new FolderOrganizer();
            var sourcePath = args.Length > 0 ? args[0] : "./";
            organizer.OrganizeFolder(sourcePath);

            Console.WriteLine("Folder organization complete.");
        }
    }
}