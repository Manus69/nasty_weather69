class Program
{
    private static readonly String s_hMsg = "Invalid hour value";
    private static readonly String s_argMsg = "Invalid arguments";
    private static readonly String s_usrMsg = "Usage: dotnet run [city] (-H | -C) (hours)";
    private static readonly String s_sep = "-----";

    private static void _in_h(List<Weather> wlst, Args args)
    {
        if (args.Hrs >= wlst.Count)
        {
            Console.WriteLine(s_hMsg);
        }
        else
        {
            Console.WriteLine(wlst[args.Hrs]);
        }
    }

    private static void _cont(List<Weather> wlst, Args args)
    {
        int lim;

        lim = args.Hrs < wlst.Count ? args.Hrs : wlst.Count;

        for (int k = 0; k < lim; k ++)
        {
            Console.WriteLine(wlst[k]);
            Console.WriteLine(s_sep);
        }
    }

    private static void _run(List<Weather> wlst, Args args)
    {
        if (! args.Cont)
        {
            _in_h(wlst, args);
        }
        else
        {
            _cont(wlst, args);
        }
    }

    public static async Task Main(String[] margs)
    {
        Args args;

        try
        {
            args = Args.Parse(margs);
            if (! args.Valid)
            {
                Console.WriteLine(s_argMsg + "\n" + s_usrMsg);
                return ;
            }

            var client = new OMWeatherClient();
            var weather = await client.GetHourlyWeather(args.City!);
            
            _run(weather, args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
