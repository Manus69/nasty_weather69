using System.Diagnostics;

struct Args
{
    public String?  City {get;}
    public int      Hrs {get;}
    public bool     Cont {get;}
    public bool     Valid {get;}

    private static readonly String s_hKey = "-H";
    private static readonly String _c_key = "-C";

    Args(String city, int hrs, bool cont, bool valid)
    {
        this.City = city;
        this.Hrs = hrs;
        this.Cont = cont;
        this.Valid = valid;
    }

    public Args()
    {
        this.Valid = false;
    }

    public static Args Parse(String[] args)
    {
        int val;

        if (args.Length == 1) return new Args(args[0], 0, false, true);
        if (args.Length != 3) return new Args();

        if (int.TryParse(args[2], out val) && val >= 0)
        {
            if (args[1] == s_hKey) return new Args(args[0], val, false, true);
            if (args[1] == _c_key) return new Args(args[0], val, true, true);
        }

        return new Args();
    }

}
