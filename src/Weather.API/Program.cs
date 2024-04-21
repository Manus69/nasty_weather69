class Program
{
    //change print
    //ui <- app
    //infrastructure <- app
    //app <- entities
    // public static async Task Main(String[] margs)
    // {
    //     try
    //     {
    //         var args = Args.Parse(margs);
    //         if (!args.Valid)
    //         {
    //             Console.WriteLine("Invalid arguments\nUsage: dotnet run [city] (-H | -C) (hours)");
    //             return;
    //         }

    //         var client = new OMWeatherClient();
    //         var weather = await client.GetHourlyWeather(args.City!);

    //         Run(weather, args);
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //     }
    // }

    public static async Task Main(string[] args)
    {
        OMWeatherClient weatherClient = new OMWeatherClient();
        WeatherService weatherService = new WeatherService(weatherClient);
        EntryPoint entryPoint = new EntryPoint(weatherService);

        await entryPoint.Run(args);
    }

    private static void InH(List<Weather> wlst, Args args)
    {
        if (args.Hrs >= wlst.Count)
        {
            Console.WriteLine("Invalid hour value");
        }
        else
        {
            Console.WriteLine(wlst[args.Hrs]);
        }
    }

    private static void Cont(List<Weather> wlst, Args args)
    {
        int lim;

        lim = args.Hrs < wlst.Count ? args.Hrs : wlst.Count;

        for (int k = 0; k < lim; k++)
        {
            Console.WriteLine(wlst[k]);
            Console.WriteLine("-----");
        }
    }

    private static void Run(List<Weather> wlst, Args args)
    {
        if (!args.Cont)
        {
            InH(wlst, args);
        }
        else
        {
            Cont(wlst, args);
        }
    }
}

// using System.Text.Json;

// var contents = File.ReadAllText("open_meteo_response.json");
// var response = JsonSerializer.Deserialize<OMResponse>(contents);

// Console.WriteLine(JsonSerializer.Serialize(response));

// class OMResponse
// {
//     public CurrentDto? current {get; set;}
//     public HourlyDto? hourly {get; set;}

// }
// class CurrentDto
// {
//     public DateTime time {get; set;}
//     public float temperature_2m {get; set;}
//     public int weather_code {get; set;}
// }

// public class HourlyDto
// {
//     public List<DateTime>? time {get; set;}
// }
