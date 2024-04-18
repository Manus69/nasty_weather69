using System.Text.Json;
using System.Text.Json.Nodes;

class OMJSONParser : IJSONParser
{
    private static String _h_key = "hourly";
    private static String _temp_key = "temperature_2m";
    private static String _pressure_key = "surface_pressure";
    private static String _precip_key = "precipitation";

    private List<T>? _get<T>(JsonNode jnode, String key)
    {

        var val = jnode[_h_key]?[key];
        var lst = JsonSerializer.Deserialize<List<T>>(val);

        return lst;
    }

    public List<float>? GetTemps(JsonNode jnode)
    {
        return _get<float>(jnode, _temp_key);
    }   

    public List<float>? GetPressure(JsonNode jnode)
    {
        return _get<float>(jnode, _pressure_key);
    }

    public List<float>? GetPrecipitation(JsonNode jnode)
    {
        return _get<float>(jnode, _precip_key);
    }
}