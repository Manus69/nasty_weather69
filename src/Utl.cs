class Utl
{
    static Dictionary<String, (float, float)> cityLL = new Dictionary<string, (float, float)>()
    {
        {"moscow", (55.75f, 37.61f)},
        {"jerusalem", (31.76f, 35.21f)},
        {"ryazan", (54.60f, 39.71f)},
        {"djibouti", (11.58f, 43.14f)},
        {"tbilisi", (41.69f, 44.82f)},
    };

    public static (float, float) GetLatLong(String city)
    {
        (float, float) ll;

        city = city.ToLower();
        if (cityLL.TryGetValue(city, out ll))
        {
            return ll;
        }

        throw new Exception("City not found");
    }
}