// 代码生成时间: 2025-08-24 20:28:59
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestfulApiExample
{
    // Define a ViewModel
    public class RestfulApiViewModel : BindableObject
    {
        private string _response;
        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged();
            }
        }

        public async Task FetchDataAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://api.example.com/data");
                response.EnsureSuccessStatusCode();
                Response = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Response = $"Error fetching data: {e.Message}";
            }
            catch (Exception e)
            {
                Response = $"An unexpected error occurred: {e.Message}";
            }
        }
    }

    // Define a ContentPage
    public class RestfulApiPage : ContentPage
    {
        private readonly RestfulApiViewModel _viewModel;
        private readonly Button _fetchDataButton;
        private readonly Label _responseLabel;

        public RestfulApiPage()
        {
            _viewModel = new RestfulApiViewModel();
            _fetchDataButton = new Button
            {
                Text = "Fetch Data",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            _fetchDataButton.Clicked += async (sender, e) => await FetchDataAsync();

            _responseLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(10),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            _responseLabel.SetBinding(Label.TextProperty, new Binding(nameof(RestfulApiViewModel.Response), source: _viewModel));

            Content = new StackLayout
            {
                Children =
                {
                    _fetchDataButton,
                    _responseLabel
                }
            };
        }

        private async Task FetchDataAsync()
        {
            // Fetch data when button is clicked and update the UI
            await _viewModel.FetchDataAsync();
            _responseLabel.Text = _viewModel.Response;
        }
    }
}
