class Program
{
    public static async Task Main(string[] args)
    {
        OMWeatherClient weatherClient = new OMWeatherClient();
        WeatherService weatherService = new WeatherService(weatherClient);
        EntryPoint entryPoint = new EntryPoint(weatherService);

        await entryPoint.Run(args);
    }
}


