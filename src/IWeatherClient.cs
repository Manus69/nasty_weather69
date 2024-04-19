
interface IWeatherClient
{
    Task<List<Weather>> GetHourlyWeather(String city);
}