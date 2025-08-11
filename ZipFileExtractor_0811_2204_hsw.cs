// 代码生成时间: 2025-08-11 22:04:20
using System;
using System.IO;
using System.IO.Compression;

/// <summary>
/// A utility class for extracting zip files.
/// </summary>
public class ZipFileExtractor
{
    /// <summary>
    /// Extracts all files from a zip archive to a specified destination.
    /// </summary>
    /// <param name="zipFilePath">The path to the zip file.</param>
    /// <param name="destinationFolder">The destination folder where the files will be extracted.</param>
    public void ExtractAllFiles(string zipFilePath, string destinationFolder)
    {
        // Check if the zip file exists
        if (!File.Exists(zipFilePath))
        {
            throw new FileNotFoundException("The zip file was not found.", zipFilePath);
        }

        // Ensure the destination folder exists, if not, create it
        Directory.CreateDirectory(destinationFolder);

        try
        {
            // Extract the zip file to the destination folder
            ZipFile.ExtractToDirectory(zipFilePath, destinationFolder);
        }
        catch (IOException ex)
        {
            // Handle IO exceptions, such as file access issues or disk full errors
            throw new IOException("An error occurred while extracting the zip file.", ex);
        }
        catch (InvalidDataException ex)
        {
            // Handle invalid zip file exceptions
            throw new InvalidDataException("The zip file is invalid or corrupted.", ex);
        }
    }
}
