
interface IWeatherClient
{
    Task<List<Weather>> GetHourlyWeather(String city);
    Task<Weather>       GetCurrentWeather(String city);
    Task<Weather>       GetDataPoint(String city, int offset);
}