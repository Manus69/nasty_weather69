class WeatherService
{
    private IWeatherClient _weatherClient;

    public WeatherService(IWeatherClient weatherClient)
    {
        _weatherClient = weatherClient;
    }

    public Task<Weather> GetCurrent(String city)
    {
        return _weatherClient.GetCurrentWeather(city);
    }

    public Task<Weather> GetDataPoint(String city, int offset)
    {
        return _weatherClient.GetDataPoint(city, offset);
    }

    public Task<List<Weather>> GetForecast(String city)
    {
        return _weatherClient.GetHourlyWeather(city);
    }
}