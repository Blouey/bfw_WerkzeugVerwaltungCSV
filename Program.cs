using System.Text;

namespace NewCSVConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        CRUD crud = new CRUD();
        
         crud.AddTool("Hammer", 5.99, 10);

        foreach (Tool tool in crud.GetAllTools())
        {
            tool.Print();
        }
        Tool t = crud.GetToolById(1007);
        crud.DeleteToolById(1007);
        
        foreach (Tool tool in crud.GetAllTools())
        {
            tool.Print();
        }

        crud.AddTool(t);



    }
}