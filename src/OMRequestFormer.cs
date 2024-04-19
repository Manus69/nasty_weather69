class OMRequestFormer : IRequestFormer
{
    private readonly String          _rq_template_head = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}";                         
    private String          _rq_template_tail = "&current=temperature_2m,precipitation,rain,showers,snowfall,weather_code,cloud_cover,surface_pressure" +
                                                "&hourly=temperature_2m,precipitation_probability,precipitation,rain,showers,snowfall,weather_code,surface_pressure,cloud_cover&" +
                                                "timezone=Europe%2FMoscow&forecast_days=3";
    public String FormRequest(String city)
    {
        var (lat, lon) = Utl.GetLatLong(city);
        
        return String.Format(_rq_template_head, lat, lon) + _rq_template_tail;
    }
}