using static NewCSVConsoleApp.CSV;
using static NewCSVConsoleApp.Other;
using System.Text;

namespace NewCSVConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        CRUD crud = new CRUD();


        switch (args.Length)
        {
            case 0:
                Console.WriteLine("no arguments given");
                Console.WriteLine("enter \"--help\" or \"/?\" for more information");
                break;
            case 1:
                switch (args[0])
                {
                    case "help":
                    case "/?":
                        Console.WriteLine("--help");
                        Console.WriteLine("--add <bezeichnung> <preis> <lagerbestand>             - zum hinzufügen eines Werkzeugs");
                        Console.WriteLine("--delete <id>                                          - zum löschen eines Werkzeugs");
                        Console.WriteLine("--sort                                                 - zum sortieren der Werkzeuge aufteigend nach ID");
                        Console.WriteLine("--sort <id|bezeichnung|preis|lagerbestand> <asc|desc>  - zum sortieren der Werkzeuge");
                        Console.WriteLine("--print                                                - zum ausgeben aller Werkzeuge");
                        Console.WriteLine("--print <id>                                           - zum ausgeben eines Werkzeugs");
                        Console.WriteLine("--clear                                                - zum leeren der Konsole");
                        Console.WriteLine("--exit                                                 - zum beenden des Programms");
                        break;
                    case "--print":
                        Loader();
                        Lul();
                        PrintAll();
                        break;
                    case "--sort":
                        List<Tool> tools = crud.GetAllTools();
                        tools.Sort();
                        PrintAll();
                        break;
                    case "--clear":
                        Console.Clear();
                        break;
                    case "--exit":
                        Environment.Exit(0);
                        break;
                    default:
                        InvalidArgs();
                        break;
                }
                break;
            case 2:
                switch (args[0])
                {
                    case "--delete":
                        if (int.TryParse(args[1], out int id))
                        {
                            crud.DeleteToolById(id);
                        }
                        else
                        {
                            InvalidArgs();
                        }
                        break;
                    case "--print":
                        if(int.TryParse(args[1], out int id2))
                        {
                            Tool tool = crud.GetToolById(id2);
                            if (tool != null) tool.Print();
                        }
                        else
                        {
                            InvalidArgs();
                        }
                        break;
                }
                break;
            case 3:
                if(args[0].Equals("--sort"))
                {
                    List<Tool> tools = crud.GetAllTools();
                    switch (args[1])
                    {
                        case "id":
                            switch (args[2])
                            {
                                case "asc":
                                    tools.Sort();
                                    break;
                                case "desc":
                                    tools.Sort(new Sorter.IdDesc());
                                    break;
                                default:
                                    InvalidArgs();
                                    return;
                            }
                            break;
                        case "bezeichnung":
                            switch (args[2])
                            {
                                case "asc":
                                    tools.Sort(new Sorter.BezeichnungAsc());
                                    break;
                                case "desc":
                                    tools.Sort(new Sorter.BezeichnungDesc());
                                    break;
                                default:
                                    InvalidArgs();
                                    return;
                            }
                            break;
                        case "preis":
                            switch (args[2])
                            {
                                case "asc":
                                    tools.Sort(new Sorter.PreisAsc());
                                    break;
                                case "desc":
                                    tools.Sort(new Sorter.PreisDesc());
                                    break;
                                default:
                                    InvalidArgs();
                                    return;
                            }
                            break;
                        case "lagerbestand":
                            switch (args[2])
                            {
                                case "asc":
                                    tools.Sort(new Sorter.BestandAsc());
                                    break;
                                case "desc":
                                    tools.Sort(new Sorter.BestandDesc());
                                    break;
                                default:
                                    InvalidArgs();
                                    return;
                            }
                            break;
                        default:
                            InvalidArgs();
                            return;
                    }
                    PrintAll();
                }
                else
                {
                    InvalidArgs();
                }
                break;
            case 4:
                if (args[0].Equals("--add"))
                {
                    if (double.TryParse(args[2], out double preis) && int.TryParse(args[3], out int lagerbestand))
                    {
                        crud.AddTool(args[1], preis, lagerbestand);
                    }
                    else
                    {
                        InvalidArgs();
                    }
                }
                else
                {
                    InvalidArgs();
                }
                break;
            default:
                InvalidArgs();
                break;
        }
        
    }
}