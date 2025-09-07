// 代码生成时间: 2025-09-07 20:40:47
using System;
using Xamarin.Forms;

namespace UrlValidatorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ValidateUrlButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string url = UrlEntry.Text;
                if (string.IsNullOrWhiteSpace(url))
                {
                    await DisplayAlert("Error", "Please enter a URL.", "OK");
                    return;
                }

                Uri uriResult;
                bool isUrlValid = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (isUrlValid)
                {
                    await DisplayAlert("Success", "The URL is valid.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "The URL is invalid.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}