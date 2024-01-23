using System.Text;

namespace NewCSVConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        CRUD crud = new CRUD();


        switch (args.Length)
        {
            case 0:
                Console.WriteLine("no arguments given");
                Console.WriteLine("enter \"help\" or \"?\" for more information");
                break;
            case 1:
                switch (args[0])
                {
                    case "help":
                    case "?":
                        Console.WriteLine("help");
                        Console.WriteLine("add <bezeichnung> <preis> <lagerbestand>             - zum hinzufügen eines Werkzeugs");
                        Console.WriteLine("delete <id>                                          - zum löschen eines Werkzeugs");
                        Console.WriteLine("sort                                                 - zum sortieren der Werkzeuge aufteigend nach ID");
                        Console.WriteLine("sort <id|bezeichnung|preis|lagerbestand> <asc|desc>  - zum sortieren der Werkzeuge");
                        Console.WriteLine("print                                                - zum ausgeben aller Werkzeuge");
                        Console.WriteLine("print <id>                                           - zum ausgeben eines Werkzeugs");
                        Console.WriteLine("exit                                                 - zum beenden des Programms");
                        break;
                    case "print":
                        foreach (Tool tool in crud.GetAllTools())
                        {
                            tool.Print();
                        }
                        break;
                    case "sort":
                        List<Tool> tools = crud.GetAllTools();
                        tools.Sort();
                        foreach (Tool tool in tools)
                        {
                            tool.Print();
                        }
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid argument");
                        Console.WriteLine("enter \"help\" or \"?\" for more information");
                        break;
                }
                break;
            case 2:
                switch (args[0])
                {
                    case "delete":
                        if (int.TryParse(args[1], out int id))
                        {
                            crud.DeleteToolById(id);
                        }
                        else
                        {
                            Console.WriteLine("invalid argument");
                            Console.WriteLine("enter \"help\" or \"?\" for more information");
                        }
                        break;
                    case "print":
                        if(int.TryParse(args[1], out int id2))
                        {
                            Tool tool = crud.GetToolById(id2);
                            if (tool != null) tool.Print();
                        }
                        else
                        {
                            Console.WriteLine("invalid argument");
                            Console.WriteLine("enter \"help\" or \"?\" for more information");
                        }
                        break;
                }
                break;
            case 3:
                if(args[0].Equals("sort"))
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
                                    Console.WriteLine("invalid argument");
                                    Console.WriteLine("enter \"help\" or \"?\" for more information");
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
                                    Console.WriteLine("invalid argument");
                                    Console.WriteLine("enter \"help\" or \"?\" for more information");
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
                                    Console.WriteLine("invalid argument");
                                    Console.WriteLine("enter \"help\" or \"?\" for more information");
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
                                    Console.WriteLine("invalid argument");
                                    Console.WriteLine("enter \"help\" or \"?\" for more information");
                                    return;
                            }
                            break;
                        default:
                            Console.WriteLine("invalid argument");
                            Console.WriteLine("enter \"help\" or \"?\" for more information");
                            return;
                    }
                    foreach (Tool tool in tools)
                    {
                        tool.Print();
                    }
                }
                else
                {
                    Console.WriteLine("invalid argument");
                    Console.WriteLine("enter \"help\" or \"?\" for more information");
                }
                break;
            case 4:
                if (args[0].Equals("add"))
                {
                    if (double.TryParse(args[2], out double preis) && int.TryParse(args[3], out int lagerbestand))
                    {
                        crud.AddTool(args[1], preis, lagerbestand);
                    }
                    else
                    {
                        Console.WriteLine("invalid argument");
                        Console.WriteLine("enter \"help\" or \"?\" for more information");
                    }
                }
                else
                {
                    Console.WriteLine("invalid argument");
                    Console.WriteLine("enter \"help\" or \"?\" for more information");
                }
                break;
            default:
                Console.WriteLine("too many arguments given");
                break;
        }
        
    }
}