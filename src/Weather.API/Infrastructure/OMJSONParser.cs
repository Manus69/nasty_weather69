using System.Text.Json;
using System.Text.Json.Nodes;

//old stuff

class OMJSONParser
{
    private static readonly String s_hKey = "hourly";
    private static readonly String s_tempKey = "temperature_2m";
    private static readonly String s_pressureKey = "surface_pressure";
    private static readonly String s_precipKey = "precipitation";
    private static readonly String s_wcodeKey = "weather_code";

    public List<float>? GetTemps(JsonNode jNode)
    {
        return get<float>(jNode, s_tempKey);
    }   

    public List<float>? GetPressure(JsonNode jNode)
    {
        return get<float>(jNode, s_pressureKey);
    }

    public List<float>? GetPrecipitation(JsonNode jNode)
    {
        return get<float>(jNode, s_precipKey);
    }

    public List<int>? GetWeatherCode(JsonNode jNode)
    {
        return get<int> (jNode, s_wcodeKey);
    }

    private List<T>? get<T>(JsonNode jNode, String key)
    {
        var val = jNode[s_hKey]?[key];
        var lst = JsonSerializer.Deserialize<List<T>>(val);

        return lst;
    }
}