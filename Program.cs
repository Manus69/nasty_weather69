// See https://aka.ms/new-console-template for more information


// using System.Text.Json.Nodes;
// string file_name = "open_meteo_response.txt";
// HttpClient client = new HttpClient();
// var response = await client.GetStringAsync(@"https://api.open-meteo.com/v1/forecast?latitude=55.75&longitude=37.61&current=temperature_2m,precipitation,rain,showers,snowfall,weather_code,cloud_cover,surface_pressure&hourly=temperature_2m,precipitation_probability,precipitation,rain,showers,snowfall,weather_code,surface_pressure,cloud_cover&timezone=Europe%2FMoscow&forecast_days=3");

// var response = File.ReadAllText(file_name);
// var jobj = JsonObject.Parse(response);
// Console.WriteLine(jobj["hourly"]["temperature_2m"]);

var client = new OMWeatherClient();
var w = client.GetHourlyWeather("cock");

w.ForEach(Console.WriteLine);