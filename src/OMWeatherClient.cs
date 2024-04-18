using System.Diagnostics;
using System.Text.Json.Nodes;

class OMWeatherClient : IWeatherClient
{
    private OMRequestFormer _rqf;
    private OMJSONParser    _parser;

    private HttpClient      _http_client;
    private String          _rq_template_head = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}";
                                            
    private String          _rq_template_tail = "&current=temperature_2m,precipitation,rain,showers,snowfall,weather_code,cloud_cover,surface_pressure" +
                                                "&hourly=temperature_2m,precipitation_probability,precipitation,rain,showers,snowfall,weather_code,surface_pressure,cloud_cover&" +
                                                "timezone=Europe%2FMoscow&forecast_days=3";

    public OMWeatherClient()
    {
        this._http_client = new HttpClient();
        this._rqf = new OMRequestFormer();
        this._parser = new OMJSONParser();
    }

    private String _form_request(String city)
    {
        var (lat, lon) = Utl.GetLatLong(city);

        return String.Format(_rq_template_head, lat, lon) + _rq_template_tail;
    }

    private String _send_request(String request)
    {
        String response;

        response = File.ReadAllText("open_meteo_response.txt");

        return response;
    }

    private List<T> _trim<T>(List<T> lst, int offset)
    {
        Debug.Assert(lst.Count >= offset);

        return lst.Slice(offset, lst.Count - offset);
    }

    private List<Weather> _get_weather(JsonNode jnode)
    {
        List<Weather>   weather_lst;
        int             len;

        var temps = this._parser.GetTemps(jnode);
        var press = this._parser.GetPressure(jnode);
        var prec = this._parser.GetPrecipitation(jnode);

        if (temps is null || press is null || prec is null) throw new Exception();

        weather_lst = new List<Weather>();
        len = temps.Count;

        for (int k = 0; k < len; k ++)
        {
            weather_lst.Add(new Weather(temps[k], prec[k], press[k]));
        }

        return _trim(weather_lst, DateTime.Now.Hour);
    }

    public List<Weather> GetHourlyWeather(String city)
    {
        String      request;
        String      response;
        JsonNode?   js_node;

        request = _form_request(city);
        response = _send_request(request);
        js_node = JsonObject.Parse(response);

        if (js_node is null) throw new Exception();

        return _get_weather(js_node);
    }
}