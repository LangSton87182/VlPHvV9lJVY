// 代码生成时间: 2025-08-20 05:23:25
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FolderOrganizerApp
{
    /// <summary>
    /// Class responsible for organizing the structure of directories.
    /// </summary>
    public class FolderOrganizer
    {
        private readonly string _sourcePath;
        private readonly string _destinationPath;

        /// <summary>
        /// Initializes a new instance of the FolderOrganizer class.
        /// </summary>
        /// <param name="sourcePath">The source directory path.</param>
        /// <param name="destinationPath">The destination directory path.</param>
        public FolderOrganizer(string sourcePath, string destinationPath)
        {
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
        }

        /// <summary>
        /// Organizes the files from the source directory into the destination directory.
        /// </summary>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task OrganizeAsync()
        {
            try
            {
                // Ensure the paths exist
                if (!Directory.Exists(_sourcePath))
                {
                    throw new DirectoryNotFoundException(\$"Source directory not found: {_sourcePath}");
                }

                if (!Directory.Exists(_destinationPath))
                {
                    Directory.CreateDirectory(_destinationPath);
                }

                // Get all files from the source directory
                var files = Directory.GetFiles(_sourcePath);

                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    // Define the destination file path
                    var destinationFile = Path.Combine(_destinationPath, fileName);

                    // Move the file to the new directory
                    await MoveFileAsync(file, destinationFile);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the organization process
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Asynchronously moves a file from one location to another.
        /// </summary>
        /// <param name="sourceFile">The source file path.</param>
        /// <param name="destinationFile">The destination file path.</param>
        /// <returns>Task representing the asynchronous file move operation.</returns>
        private async Task MoveFileAsync(string sourceFile, string destinationFile)
        {
            // Overwrite the destination file if it already exists
            if (File.Exists(destinationFile))
            {
                File.Delete(destinationFile);
            }

            // Move the file asynchronously
            await Task.Run(() => File.Move(sourceFile, destinationFile));
        }
    }
}
