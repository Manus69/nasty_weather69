class Weather
{
    float   temp;
    float?  precipitation;
    float?  pressure;
    int?    code;

    public Weather(float temp, float? precipitation=null, float? pressure=null, int? code=null)
    {
        this.temp = temp;
        this.precipitation = precipitation;
        this.pressure = pressure;
        this.code = code;
    }

    public override string ToString()
    {
        String? _to_str(Object? obj)
        {
            return obj is null ? "_" : obj.ToString();
        }

        return $"temp: {this.temp} C precipitation: {_to_str(this.precipitation)} mm pressure: {_to_str(this.pressure)} hPa code: {_to_str(this.code)}";
    }
}