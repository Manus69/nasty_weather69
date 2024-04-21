class OMURLFormer
{
    private readonly String rqTemplateHead = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}";                         
    private String          rqTemplateTail = "&current=temperature_2m,precipitation,rain,showers,snowfall,weather_code,cloud_cover,surface_pressure" +
                                                "&hourly=temperature_2m,precipitation_probability,precipitation,rain,showers,snowfall,weather_code,surface_pressure,cloud_cover&" +
                                                "timezone=Europe%2FMoscow&forecast_days=3";
    public String FormForecastForCityURL(String city)
    {
        var (lat, lon) = CityCoords.GetLatLong(city);

        return String.Format(rqTemplateHead, lat, lon) + rqTemplateTail;
    }
}