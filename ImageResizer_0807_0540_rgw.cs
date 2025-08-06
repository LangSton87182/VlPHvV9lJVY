// 代码生成时间: 2025-08-07 05:40:51
using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ImageResizerApp
{
    public class ImageResizer
    {
        /// <summary>
        /// Resizes images in the specified directory.
        /// </summary>
        /// <param name="sourceDirectory">The directory containing the original images.</param>
        /// <param name="targetDirectory">The directory where the resized images will be saved.</param>
        /// <param name="width">The desired width for the resized images.</param>
        /// <param name="height">The desired height for the resized images.</param>
        public async void ResizeImages(string sourceDirectory, string targetDirectory, int width, int height)
        {
            // Check if the source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.WriteLine("Source directory does not exist.");
                return;
            }

            // Create the target directory if it does not exist
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            // Get all image files from the source directory
            var imageFiles = Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories);
            foreach (var file in imageFiles)
            {
                try
                {
                    // Resize image and save to target directory
                    ResizeImage(file, targetDirectory, width, height);
                }
                catch (Exception ex)
                {
                    // Log the error for the current image
                    Console.WriteLine($"Error resizing image {Path.GetFileName(file)}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Resizes a single image and saves it to the target directory.
        /// </summary>
        /// <param name="sourceFile">The path to the source image file.</param>
        /// <param name="targetDirectory">The directory where the resized image will be saved.</param>
        /// <param name="width">The desired width for the resized image.</param>
        /// <param name="height">The desired height for the resized image.</param>
        private void ResizeImage(string sourceFile, string targetDirectory, int width, int height)
        {
            // Load the image
            var bitmap = BitmapFactory.DecodeFile(sourceFile);

            // Create a new bitmap with the desired dimensions
            var resizedBitmap = Bitmap.CreateScaledBitmap(bitmap, width, height, true);

            // Create a path for the resized image
            var targetFile = Path.Combine(targetDirectory, Path.GetFileName(sourceFile));

            // Save the resized image to the target directory
            using (var stream = File.OpenWrite(targetFile))
            {
                resizedBitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            }

            // Dispose of the bitmaps to free up resources
            bitmap.Dispose();
            resizedBitmap.Dispose();
        }
    }
}
