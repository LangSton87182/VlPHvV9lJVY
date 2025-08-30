// 代码生成时间: 2025-08-30 16:56:53
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FolderStructureManager
{
    // 文件夹结构整理器类
    public class FolderStructureManager
    {
        private readonly string _sourceFolderPath;
        private readonly string _destinationFolderPath;

        // 构造函数
        public FolderStructureManager(string sourceFolderPath, string destinationFolderPath)
        {
            _sourceFolderPath = sourceFolderPath;
            _destinationFolderPath = destinationFolderPath;
        }

        // 整理文件夹结构
        public void OrganizeFolders()
        {
            try
            {
                if (!Directory.Exists(_sourceFolderPath))
                {
                    throw new ArgumentException("Source folder does not exist.");
                }

                // 创建目标文件夹路径
                Directory.CreateDirectory(_destinationFolderPath);

                // 获取源文件夹中的所有文件
                var files = Directory.GetFiles(_sourceFolderPath);

                foreach (var file in files)
                {
                    // 根据文件类型创建子文件夹
                    var fileExtension = Path.GetExtension(file).ToLower();
                    var folderName = fileExtension == "" ? "Others" : fileExtension.TrimStart('.');
                    var folderPath = Path.Combine(_destinationFolderPath, folderName);

                    // 创建子文件夹
                    Directory.CreateDirectory(folderPath);

                    // 移动文件到相应的子文件夹
                    File.Move(file, Path.Combine(folderPath, Path.GetFileName(file)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    // 程序入口类
    class Program
    {
        static void Main(string[] args)
        {
            // 示例路径，需要根据实际情况进行修改
            string sourceFolder = @"C:\Users\ExampleUser\Downloads\SourceFolder";
            string destinationFolder = @"C:\Users\ExampleUser\Downloads\OrganizedFolder";

            // 创建文件夹结构整理器实例
            var folderManager = new FolderStructureManager(sourceFolder, destinationFolder);

            // 开始整理文件夹结构
            folderManager.OrganizeFolders();

            Console.WriteLine("Folder structure organized successfully.");
        }
    }
}