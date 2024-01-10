using Alvarez_EjemploAPI.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Alvarez_EjemploAPI.Views;

public partial class ClimaActual : ContentPage
{
	public ClimaActual()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
		string longitud = lon.Text;

		if(Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			using (var client = new HttpClient())
			{
				string url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=486cac8b9c205ff94d6c8895944c74ae\r\n";
				var response =  await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var json  = await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);

					weatherLabel.Text = clima.weather[0].main;
				}

			}
		}

    }
}