// 代码生成时间: 2025-08-18 14:14:26
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace XamarinApp
{
    /// <summary>
    /// A utility class to organize folder structure.
    /// </summary>
    public class FolderOrganizer
    {
        private readonly string _sourceFolderPath;
        private readonly string _destinationFolderPath;
        private readonly Dictionary<string, List<string>> _fileMap;

        /// <summary>
        /// Initializes a new instance of the FolderOrganizer class.
        /// </summary>
        /// <param name="sourceFolderPath">The path to the source folder.</param>
        /// <param name="destinationFolderPath">The path to the destination folder.</param>
        public FolderOrganizer(string sourceFolderPath, string destinationFolderPath)
        {
            _sourceFolderPath = sourceFolderPath ?? throw new ArgumentNullException(nameof(sourceFolderPath));
            _destinationFolderPath = destinationFolderPath ?? throw new ArgumentNullException(nameof(destinationFolderPath));
            _fileMap = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// Organizes the files from the source folder to the destination folder.
        /// </summary>
        public void OrganizeFolders()
        {
            try
            {
                // Ensure the source and destination folders exist
                if (!Directory.Exists(_sourceFolderPath))
                {
                    throw new DirectoryNotFoundException($"Source folder not found: {_sourceFolderPath}");
                }

                // Create the destination folder if it doesn't exist
                Directory.CreateDirectory(_destinationFolderPath);

                // Scan all files in the source folder and map them to their respective categories
                MapFiles();

                // Move files to the destination folder based on the map
                MoveFiles();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process
                Console.WriteLine($"An error occurred while organizing folders: {ex.Message}");
            }
        }

        /// <summary>
        /// Maps files to their respective categories based on file extension.
        /// </summary>
        private void MapFiles()
        {
            foreach (var file in Directory.GetFiles(_sourceFolderPath))
            {
                var fileExtension = Path.GetExtension(file);
                if (!_fileMap.ContainsKey(fileExtension))
                {
                    _fileMap[fileExtension] = new List<string>();
                }
                _fileMap[fileExtension].Add(file);
            }
        }

        /// <summary>
        /// Moves files to the destination folder based on the file map.
        /// </summary>
        private void MoveFiles()
        {
            foreach (var fileCategory in _fileMap)
            {
                var categoryFolderPath = Path.Combine(_destinationFolderPath, fileCategory.Key.TrimStart('.'));
                Directory.CreateDirectory(categoryFolderPath);

                foreach (var filePath in fileCategory.Value)
                {
                    var fileName = Path.GetFileName(filePath);
                    var destinationFilePath = Path.Combine(categoryFolderPath, fileName);
                    File.Move(filePath, destinationFilePath);
                }
            }
        }
    }
}
