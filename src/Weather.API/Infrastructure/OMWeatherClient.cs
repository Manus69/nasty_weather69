using System.Text.Json;
using System.Text.Json.Nodes;

class OMWeatherClient : IWeatherClient
{
    private OMURLFormer _requestFormer;
    private HttpClient  _httpClient;
    private static string _msgInvalidResp = "Invalid response";
    private static string _msgInvalidOffset = "Invalid offset";
    
    public OMWeatherClient()
    {
        _httpClient = new HttpClient();
        _requestFormer = new OMURLFormer();
    }

    public async Task<List<Weather>> GetHourlyWeather(String city)
    {
        List<Weather> weather;
        var dto = await GetResponse(city);

        if (dto.hourly is null) throw new Exception(_msgInvalidResp);
        if (dto.hourly.temperature_2m is null) throw new Exception(_msgInvalidResp);

        weather = [];
        for (int k = DateTime.Now.Hour; k < dto.hourly.temperature_2m.Count; k ++)
        {
            weather.Add(GetWeatherDataPoint(dto, k));
        }

        return weather;
    }

    public async Task<Weather> GetCurrentWeather(String city)
    {
        var dto = await GetResponse(city);

        if (dto.current is null) throw new Exception(_msgInvalidResp);

        return new Weather(dto.current.temperature_2m, dto.current.precipitation, dto.current.surface_pressure, dto.current.weather_code);
    }

    public async Task<Weather> GetDataPoint(String city, int offset)
    {
        var weather = await GetHourlyWeather(city);

        if (offset >= weather.Count) throw new Exception(_msgInvalidOffset);

        return weather[offset];
    }

    private Weather GetWeatherDataPoint(OMResponse response, int k)
    {
        float?  pressure = null;
        float?  precipitation = null;
        int?    code = null;

        if (response.hourly!.surface_pressure is not null) pressure = response.hourly.surface_pressure.ElementAtOrDefault(k);
        if (response.hourly.precipitation is not null) precipitation = response.hourly.precipitation.ElementAtOrDefault(k);
        if (response.hourly.weather_code is not null) code = response.hourly.weather_code.ElementAtOrDefault(k);

        return new Weather(response.hourly.temperature_2m![k], precipitation, pressure, code);
    }

    private async Task<OMResponse> GetResponse(String city)
    {
        var url = _requestFormer.FormForecastForCityURL(city);
        var response = await _httpClient.GetStringAsync(url);
        var dto = JsonSerializer.Deserialize<OMResponse>(response);

        if (dto is null) throw new Exception(_msgInvalidResp);

        return dto;
    }

}