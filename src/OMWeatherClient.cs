using System.Diagnostics;
using System.Text.Json.Nodes;

class OMWeatherClient : IWeatherClient
{
    private OMRequestFormer rqf;
    private OMJSONParser    parser;
    private HttpClient      httpClient;
    
    public OMWeatherClient()
    {
        this.httpClient = new HttpClient();
        this.rqf = new OMRequestFormer();
        this.parser = new OMJSONParser();
    }

    public async Task<List<Weather>> GetHourlyWeather(String city)
    {
        String      request;
        String      response;
        JsonNode?   jsNode;

        request = rqf.FormRequest(city);
        response = await httpClient.GetStringAsync(request);
        jsNode = JsonObject.Parse(response);

        if (jsNode is null) throw new Exception();

        return getWeather(jsNode);
    }
    private static List<T> trim<T>(List<T> lst, int offset)
    {
        Debug.Assert(lst.Count >= offset);

        return lst.Slice(offset, lst.Count - offset);
    }

    private List<Weather> getWeather(JsonNode jNode)
    {
        List<Weather>   weatherLst;
        int             len;

        var temps = this.parser.GetTemps(jNode);
        var press = this.parser.GetPressure(jNode);
        var prec = this.parser.GetPrecipitation(jNode);
        var wcode = this.parser.GetWeatherCode(jNode);

        if (temps is null || press is null || prec is null || wcode is null) throw new Exception();

        weatherLst = new List<Weather>();
        len = temps.Count;

        for (int k = 0; k < len; k ++)
        {
            weatherLst.Add(new Weather(temps[k], prec[k], press[k], wcode[k]));
        }

        return trim(weatherLst, DateTime.Now.Hour);
    }
}