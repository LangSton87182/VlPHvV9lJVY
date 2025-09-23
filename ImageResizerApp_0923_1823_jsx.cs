// 代码生成时间: 2025-09-23 18:23:13
using SkiaSharp;
using System;
using System.IO;
using Xamarin.Forms;

namespace ImageResizerApp
{
    public class ImageResizerApp : ContentPage
    {
        public ImageResizerApp()
        {
            // Initialize components
            var layout = new StackLayout();
            var inputDirectoryEntry = new Entry()
            {
                Placeholder = "Input directory",
                Keyboard = Keyboard.Plain
            };
            var outputDirectoryEntry = new Entry()
            {
                Placeholder = "Output directory",
                Keyboard = Keyboard.Plain
            };
            var resizeFactorEntry = new Entry()
            {
                Placeholder = "Resize factor (e.g. 0.5 for half size)",
                Keyboard = Keyboard.Numeric
            };
            var resizeButton = new Button()
            {
                Text = "Resize Images"
            };
            resizeButton.Clicked += OnResizeButtonClicked;

            layout.Children.Add(inputDirectoryEntry);
            layout.Children.Add(outputDirectoryEntry);
            layout.Children.Add(resizeFactorEntry);
            layout.Children.Add(resizeButton);

            Content = layout;
        }

        private async void OnResizeButtonClicked(object sender, EventArgs e)
        {
            string inputDirectory = ((Entry)sender).Parent.Children[0] as Entry;
            string outputDirectory = ((Entry)sender).Parent.Children[1] as Entry;
            string resizeFactorText = ((Entry)sender).Parent.Children[2] as Entry;
            
            try
            {
                double resizeFactor = double.Parse(resizeFactorText.Text);
                await ResizeImagesAsync(inputDirectory.Text, outputDirectory.Text, resizeFactor);
                await DisplayAlert("Success", "Images have been resized.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task ResizeImagesAsync(string inputDirectory, string outputDirectory, double resizeFactor)
        {
            var files = Directory.GetFiles(inputDirectory);
            foreach (var file in files)
            {
                using (var inputStream = File.OpenRead(file))
                {
                    using (var image = SKBitmap.Decode(inputStream))
                    {
                        int newWidth = (int)(image.Width * resizeFactor);
                        int newHeight = (int)(image.Height * resizeFactor);
                        using (var resizedImage = image.Resize(new SKImageInfo(newWidth, newHeight), SKFilterQuality.High))
                        {
                            string outputFile = Path.Combine(outputDirectory, Path.GetFileName(file));
                            using (var outputStream = File.OpenWrite(outputFile))
                            {
                                resizedImage.Encode(SKEncodedImageFormat.Jpeg, 90).SaveTo(outputStream);
                            }
                        }
                    }
                }
            }
        }
    }
}
