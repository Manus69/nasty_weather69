class Program
{
    private static String _h_msg = "Invalid hour value";
    private static String _arg_msg = "Invalid arguments";
    private static String _user_msg = "Usage: dotnet run [city] (-H | -C) (hours)";
    private static String _sep = "-----";

    private static void _in_h(List<Weather> wlst, Args args)
    {
        if (args.hrs >= wlst.Count)
        {
            Console.WriteLine(_h_msg);
        }
        else
        {
            Console.WriteLine(wlst[args.hrs]);
        }
    }

    private static void _cont(List<Weather> wlst, Args args)
    {
        int lim;

        lim = args.hrs < wlst.Count ? args.hrs : wlst.Count;

        for (int k = 0; k < lim; k ++)
        {
            Console.WriteLine(wlst[k]);
            Console.WriteLine(_sep);
        }
    }

    private static void _run(List<Weather> wlst, Args args)
    {
        if (! args.cont)
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
            if (! args.valid)
            {
                Console.WriteLine(_arg_msg + "\n" + _user_msg);
                return ;
            }

            var client = new OMWeatherClient();
            var weather = await client.GetHourlyWeather(args.city!);
            
            _run(weather, args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
