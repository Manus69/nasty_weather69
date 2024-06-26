record Weather(float temp, float? precipitation=null, float? pressure=null, int? code=null)
{
    public override string ToString()
    {
        String result;

        String? _to_str(Object? obj)
        {
            return obj is null ? "_" : obj.ToString();
        }

        result = $"temp: {this.temp} C precipitation: {_to_str(this.precipitation)} mm pressure: {_to_str(this.pressure)} hPa ";
        if (code is not null) result += WMOCode.GetCodeString((int)code);

        return result;
    }
}