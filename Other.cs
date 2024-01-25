namespace NewCSVConsoleApp;

public static class Other
{
    public static void Lul()
    {
        Console.Write("\r                         \r");
        Console.Write("PENIS \r");
        Thread.Sleep(200);
    }

    public static void Loader()
    {
        string[] text = ["Loading results ", ".", ".", ".","\r"]; 
        Thread.Sleep(300);
        foreach (string s in text)
        {
            Console.Write(s);
            Thread.Sleep(200);
        }
        
    }

    public static void InvalidArgs()
    {
        Console.WriteLine("invalid argument(s)");
        Console.WriteLine("enter \"--help\" or \"/?\" for more information");
    }
}