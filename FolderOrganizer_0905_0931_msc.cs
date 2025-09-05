// 代码生成时间: 2025-09-05 09:31:23
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// This class is responsible for organizing the folders by moving files into
/// subdirectories based on their extensions.
/// </summary>
public class FolderOrganizer
{
    private readonly string _sourceDirectory;
    private readonly string _destinationDirectory;

    /// <summary>
    /// Initializes a new instance of the FolderOrganizer class.
    /// </summary>
    /// <param name="sourceDirectory">The directory to organize.</param>
    /// <param name="destinationDirectory">The root directory where organized subdirectories will be created.</param>
    public FolderOrganizer(string sourceDirectory, string destinationDirectory)
    {
        _sourceDirectory = sourceDirectory ?? throw new ArgumentNullException(nameof(sourceDirectory));
        _destinationDirectory = destinationDirectory ?? throw new ArgumentNullException(nameof(destinationDirectory));
    }

    /// <summary>
    /// Organizes the files in the source directory.
    /// </summary>
    public void OrganizeFolders()
    {
        if (!Directory.Exists(_sourceDirectory))
        {
            throw new DirectoryNotFoundException($"Source directory {_sourceDirectory} not found.");
        }

        var files = Directory.GetFiles(_sourceDirectory);
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var fileExtension = Path.GetExtension(fileName).TrimStart('.');

            var targetDirectory = Path.Combine(_destinationDirectory, fileExtension);
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            var targetFile = Path.Combine(targetDirectory, fileName);
            File.Move(file, targetFile);
        }
    }
}

/// <summary>
/// Program class to demonstrate the functionality of the FolderOrganizer class.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var sourceDir = @"C:\path	o\source\directory";
            var destDir = @"C:\path	o\destination\directory";

            var organizer = new FolderOrganizer(sourceDir, destDir);
            organizer.OrganizeFolders();

            Console.WriteLine("Files have been organized into subdirectories based on their extensions.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}