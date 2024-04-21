class EntryPoint
{
    private WeatherService _weatherService;
    public static int ErrCode = 1;
    public static int NoErrCode = 0;

    public EntryPoint(WeatherService weatherService)
    {
        _weatherService = weatherService;
    } 

    public async Task<int> Run(String[] str_args)
    {
        Args args = Args.Parse(str_args);

        if (! args.Valid)
        {
            Console.WriteLine("Invalid args");

            return ErrCode;
        }

        if (args.Cont)
        {
            var weather = await _weatherService.GetForecast(args.City!);
            Display(weather, args.Hrs);
        }
        else if (args.Hrs != 0)
        {
            var weather = await _weatherService.GetDataPoint(args.City!, args.Hrs);
            Display([weather], 1);
        }
        else
        {
            var weather = await _weatherService.GetCurrent(args.City!);
            Display([weather], 1);
        }

        return NoErrCode;
    }

    private void Display(List<Weather> weather, int count)
    {
        if (weather.Count == 0) throw new Exception("No data");
        count = count > weather.Count ? weather.Count : count;

        Console.WriteLine(weather[0]);
        for (int k = 1; k < count; k ++)
        {
            Console.WriteLine("-----");
            Console.WriteLine(weather[k]);
        }
    }
}