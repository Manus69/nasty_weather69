using System.Diagnostics;

struct Args
{
    public String?  city {get;}
    public int      hrs {get;}
    public bool     cont {get;}
    public bool     valid {get;}

    private static String _h_key = "-H";
    private static String _c_key = "-C";

    Args(String city, int hrs, bool cont, bool valid)
    {
        this.city = city;
        this.hrs = hrs;
        this.cont = cont;
        this.valid = valid;
    }

    public Args()
    {
        this.valid = false;
    }

    public static Args Parse(String[] args)
    {
        int val;

        if (args.Length == 1) return new Args(args[0], 0, false, true);
        if (args.Length != 3) return new Args();

        if (int.TryParse(args[2], out val) && val >= 0)
        {
            if (args[1] == _h_key) return new Args(args[0], val, false, true);
            if (args[1] == _c_key) return new Args(args[0], val, true, true);
        }

        return new Args();
    }

}
