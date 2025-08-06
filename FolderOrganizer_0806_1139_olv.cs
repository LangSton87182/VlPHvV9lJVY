// 代码生成时间: 2025-08-06 11:39:55
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// 文件夹结构整理器
public class FolderOrganizer
{
    // 构造函数，传入需要整理的根目录路径
    public FolderOrganizer(string rootPath)
    {
        if (string.IsNullOrEmpty(rootPath))
        {
            throw new ArgumentException("Root path cannot be null or empty.");
        }

        this.RootPath = rootPath;
    }

    private string RootPath { get; set; }

    // 执行文件夹整理
    public void OrganizeFolders()
    {
        try
        {
            Console.WriteLine($"Starting to organize folders in {RootPath}...");

            // 获取根目录下的所有子目录
            var directories = Directory.GetDirectories(RootPath).ToList();

            // 对每个子目录进行整理
            foreach (var directory in directories)
            {
                OrganizeDirectory(directory);
            }

            Console.WriteLine("Well done organizing folders!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // 对单个目录进行整理
    private void OrganizeDirectory(string path)
    {
        // 获取目录下的所有文件
        var files = Directory.GetFiles(path);

        // 根据文件类型进行分类整理，这里以.txt和.jpg为例
        var txtFiles = files.Where(f => f.EndsWith(".txt")).ToList();
        var jpgFiles = files.Where(f => f.EndsWith(".jpg")).ToList();

        // 创建新的分类目录
        var txtDirectory = Path.Combine(path, "TextFiles");
        var jpgDirectory = Path.Combine(path, "ImageFiles");

        // 如果分类目录不存在，则创建
        if (!Directory.Exists(txtDirectory))
        {
            Directory.CreateDirectory(txtDirectory);
        }
        if (!Directory.Exists(jpgDirectory))
        {
            Directory.CreateDirectory(jpgDirectory);
        }

        // 移动文件到对应的分类目录
        foreach (var txtFile in txtFiles)
        {
            File.Move(txtFile, Path.Combine(txtDirectory, Path.GetFileName(txtFile)));
        }
        foreach (var jpgFile in jpgFiles)
        {
            File.Move(jpgFile, Path.Combine(jpgDirectory, Path.GetFileName(jpgFile)));
        }
    }
}

// 程序的主入口
class Program
{
    static void Main(string[] args)
    {
        // 使用示例
        try
        {
            var organizer = new FolderOrganizer("C:\YourFolderPath");
            organizer.OrganizeFolders();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}