// 代码生成时间: 2025-09-08 21:24:57
// <summary>
// A utility class for file backup and synchronization.
// </summary>
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileBackupAndSyncTool
{
    // Define the class for file backup and synchronization.
    public class FileBackupAndSyncTool
    {
        private readonly string sourceDirectory;
        private readonly string backupDirectory;

        // Constructor to initialize the source and backup directories.
        public FileBackupAndSyncTool(string source, string backup)
        {
            sourceDirectory = source;
            backupDirectory = backup;
        }

        // Method to perform file backup.
        public void BackupFiles()
        {
            try
            {
                // Check if source directory exists
                if (!Directory.Exists(sourceDirectory))
                {
                    throw new DirectoryNotFoundException($"Source directory not found: {sourceDirectory}");
                }

                // Check if backup directory exists, if not create it.
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                // Get all files from source directory.
                var files = Directory.GetFiles(sourceDirectory);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var backupFilePath = Path.Combine(backupDirectory, fileName);

                    // Copy the file to backup directory.
                    File.Copy(file, backupFilePath, true);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during backup.
                Console.WriteLine($"Error occurred during backup: {ex.Message}");
            }
        }

        // Method to perform file synchronization.
        public void SyncFiles()
        {
            try
            {
                // Check if both directories exist.
                if (!Directory.Exists(sourceDirectory) || !Directory.Exists(backupDirectory))
                {
                    throw new DirectoryNotFoundException("There are missing directories.");
                }

                // Get all files from both directories.
                var sourceFiles = Directory.GetFiles(sourceDirectory);
                var backupFiles = Directory.GetFiles(backupDirectory);

                // Find files that are different or missing.
                var filesToAdd = sourceFiles.Except(backupFiles).ToList();
                var filesToRemove = backupFiles.Except(sourceFiles).ToList();

                foreach (var file in filesToAdd)
                {
                    var fileName = Path.GetFileName(file);
                    var backupFilePath = Path.Combine(backupDirectory, fileName);

                    // Copy the file to backup directory.
                    File.Copy(file, backupFilePath, true);
                }

                foreach (var file in filesToRemove)
                {
                    var fileName = Path.GetFileName(file);
                    var sourceFilePath = Path.Combine(sourceDirectory, fileName);

                    // Move the file from backup directory to a temp directory,
                    // this simulates file removal.
                    var tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Temp), fileName);
                    File.Move(file, tempFilePath);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during synchronization.
                Console.WriteLine($"Error occurred during synchronization: {ex.Message}");
            }
        }
    }

    // Main class to run the program.
    class Program
    {
        static void Main(string[] args)
        {
            var sourceDir = @"C:\SourceDirectory";
            var backupDir = @"C:\BackupDirectory";

            var backupSyncTool = new FileBackupAndSyncTool(sourceDir, backupDir);

            // Perform backup of files.
            backupSyncTool.BackupFiles();

            // Perform synchronization of files.
            backupSyncTool.SyncFiles();

            Console.WriteLine("Backup and synchronization complete.");
        }
    }
}
