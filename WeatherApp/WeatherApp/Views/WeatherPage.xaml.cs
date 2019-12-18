using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            Title = "Sample Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;
            BindingContext = new WeatherData();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                WeatherData data = await Core.GetWeather(zipCodeEntry.Text);
                this.BindingContext = data;
                getWeatherBtn.Text = "Search Again";
            }
        }

    }
}