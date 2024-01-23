namespace NewCSVConsoleApp;
using static CSV;
public class CRUD
{
    private const string Path = @"..\..\..\Werkzeug.csv";

    public bool AddTool(Tool tool)
    {
        try
        {
            List<Tool> tools = GetAll(Path);
            tools.Add(tool);
            WriteToCsv(tools);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    public bool AddTool(string bezeichnung, double preis, int lagerbestand)
    {
        try
        {
            List<Tool> tools = GetAll(Path);
            tools.Add(new Tool(bezeichnung, preis, lagerbestand));
            WriteToCsv(tools);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public bool DeleteToolById(int id)
    {
        try
        {
            List<Tool> tools = GetAll(Path);
            foreach (Tool tool in tools)
            {
                if (tool.WerkzeugId == id)
                {
                    tools.Remove(tool);
                    WriteToCsv(tools);
                    return true;
                }
            }
            
        } catch (Exception e)
        {
            Console.WriteLine(e.Message); 
        }

        Console.WriteLine($"Tool with ID: {id} not found");
        return false;
    }
    
    public bool UpdateTool(Tool toolToUpdate)
    {
        try
        {
            List<Tool> tools = GetAll(Path);
            foreach (Tool tool in tools)
            {
                if (tool.WerkzeugId == toolToUpdate.WerkzeugId)
                {
                    tools.Remove(tool);
                    tools.Add(toolToUpdate);
                    WriteToCsv(tools);
                    return true;
                }
            }
            
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine($"Tool with ID: {toolToUpdate.WerkzeugId} not found");
        return false;
    }
    
    public Tool GetToolById(int id)
    {
        try
        {
            List<Tool> tools = GetAll(Path);
            foreach (Tool tool in tools)
            {
                if (tool.WerkzeugId == id)
                {
                    return tool;
                }
            }
        } catch (Exception e)
        {
            Console.WriteLine(e.Message); 
        }

        throw new Exception($"Tool with ID: {id} not found");
    }
    
    public List<Tool> GetAllTools()
    {
        try
        {
            return GetAll(Path);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    private bool WriteToCsv(List<Tool> tools)
    {
        try
        {
            string[] comments = ReadFromCsv();
            List<string> lines = new List<string>();
            foreach (string comment in comments)
            {
                if(comment[0].Equals('#')) lines.Add(comment);
            }
            foreach (Tool tool in tools)
            {
                lines.Add($"{tool.WerkzeugId};{tool.Bezeichnung};{tool.Preis};{tool.Lagerbestand}");
            }

            File.WriteAllLines(Path, lines);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    private string[] ReadFromCsv()
    {
        try
        {
            return Read(Path);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}