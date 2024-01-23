namespace NewCSVConsoleApp;
using static CRUD;
internal class CSV
{
    public static string Path = @"..\..\..\Werkzeug.csv";

    public static string[] Read(string? path)
    {
        if (path == null) path = Path;
        
        return File.ReadAllLines(path);
    }

    public static List<Tool> GetAll(string path)
    {
        try
        {
            string[] lineArray = File.ReadAllLines(path);
            List<Tool> toolListe = new List<Tool>();

            foreach (string tool in lineArray) // create new Tool objects & add to List if valid
            {
                if(tool[0].Equals('#')) continue; // skip lines starting with '#' (comments)
                string[] dataLine = tool.Split(';');
                if (dataLine.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"invalid line {Array.IndexOf(lineArray, tool) + 1} in {path}");
                    Console.ResetColor();
                    continue;
                }
                string idString = dataLine[0];
                bool canConvert = int.TryParse(idString, out int id);
                string bezeichnung = dataLine[1];
                string preisRaw = dataLine[2];
                string bestandRaw = dataLine[3];
                bool canConvert2 = double.TryParse(preisRaw, out double preis);
                bool canConvert3 = int.TryParse(bestandRaw, out int bestand);
                
                if (!canConvert || !canConvert2 || !canConvert3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        $"cannot parse values of line {Array.IndexOf(lineArray, tool) + 1} in {path}");
                    Console.ResetColor();
                    continue;
                }

                toolListe.Add(new Tool(bezeichnung, preis, bestand, id));
            }

            return toolListe;
        }
        catch (FileNotFoundException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            return new List<Tool>();
        }
    }
    
    
}