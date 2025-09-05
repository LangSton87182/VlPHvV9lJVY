// 代码生成时间: 2025-09-06 07:17:28
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FolderOrganizer
{
    public class FolderOrganizerService
    {
        // 构造函数，初始化根目录
        public FolderOrganizerService(string rootDirectory)
        {
            if (!Directory.Exists(rootDirectory))
            {
                throw new ArgumentException("Root directory does not exist.", nameof(rootDirectory));
            }
            RootDirectory = rootDirectory;
        }

        // 根目录
        private readonly string RootDirectory;

        // 整理文件夹结构
        public void OrganizeFolders()
        {
            try
            {
                // 获取根目录下的所有文件夹
                var directories = Directory.GetDirectories(RootDirectory);

                // 遍历每个子目录
                foreach (var directory in directories)
                {
                    OrganizeSubfolders(directory);
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // 递归整理子文件夹
        private void OrganizeSubfolders(string currentDirectory)
        {
            try
            {
                // 获取当前目录下的所有文件和文件夹
                var files = Directory.GetFiles(currentDirectory);
                var subdirectories = Directory.GetDirectories(currentDirectory);

                // 按文件类型组织文件
                var organizedFiles = files.GroupBy(file => Path.GetExtension(file))
                    .ToDictionary(group => group.Key, group => group.ToList());

                // 创建新的文件夹以存放不同类型的文件
                foreach (var fileGroup in organizedFiles)
                {
                    var folderPath = Path.Combine(currentDirectory, fileGroup.Key.TrimStart('.'));
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // 移动文件到新的文件夹
                    foreach (var file in fileGroup.Value)
                    {
                        File.Move(file, Path.Combine(folderPath, Path.GetFileName(file)));
                    }
                }

                // 递归整理子文件夹
                foreach (var subdirectory in subdirectories)
                {
                    OrganizeSubfolders(subdirectory);
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred in {currentDirectory}: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 示例使用FolderOrganizerService
            try
            {
                var rootDir = @"C:\Users\ExampleUser\Documents\RootFolder";
                var organizer = new FolderOrganizerService(rootDir);
                organizer.OrganizeFolders();
                Console.WriteLine("Folder organization complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to organize folders: {ex.Message}");
            }
        }
    }
}