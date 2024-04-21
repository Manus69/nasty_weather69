class WMOCode
{
    private static readonly Dictionary<int, String> s_dict = new Dictionary<int, string>()
    {
        {0, "Clear"},
        {1, "Mainly clear"},
        {2, "Partly cloudy"},
        {3, "Cloudy"},
        {45, "Foggy"},
        {48, "Rime fog"},
        {51, "Light drizzle"},
        {53, "Drizzle"},
        {55, "Heavy drizzle"},
        {56, "Light freezing drizzle"},
        {57, "Freezing drizzle"},
        {61, "Light rain"},
        {63, "Rain"},
        {65, "Heavy rain"},
        {66, "Light freezing rain"},
        {67, "Freezing rain"},
        {71, "Light snow"},
        {73, "Snow"},
        {75, "Heavy snow"},
        {77, "Snow grains"},
        {80, "Light showers"},
        {81, "Showers"},
        {82, "Heavy showers"},
        {85, "Light snow showers"},
        {86, "Snow showers"},
        {95, "Thunderstorm"},
        {96, "Light thunderstorm with hail"},
        {99, "Thunderstorm with hail"},
    };

    public static String GetCodeString(int code)
    {
        String? str;

        if (s_dict.TryGetValue(code, out str))
        {
            return str;
        }

        return "Unrecognized WMO code";
    }
}