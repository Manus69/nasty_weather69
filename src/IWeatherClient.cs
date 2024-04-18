
interface IWeatherClient
{
    List<Weather>? GetHourlyWeather(String city);
}