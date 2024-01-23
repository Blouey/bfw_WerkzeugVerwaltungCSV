namespace NewCSVConsoleApp;
using static CSV;
public class Tool:IComparable<Tool>
{
    public int WerkzeugId { get; set; }
    public string Bezeichnung { get; set; }
    public double Preis { get; set; }
    public int Lagerbestand { get; set; }
    
    public Tool(string bezeichnung, double preis, int lagerbestand,int werkzeugId = 0)
    {
        if (werkzeugId == 0) werkzeugId = newId();
        
        WerkzeugId = werkzeugId;
        Bezeichnung = bezeichnung;
        Preis = preis;
        Lagerbestand = lagerbestand;
    }
    
    public int CompareTo(Tool? other)
    {
        return WerkzeugId.CompareTo(other?.WerkzeugId);
    }
    
    private int newId()
    {
       List<Tool> check = GetAll(Path);
      
       for(int i = 1001; i<Int32.MaxValue; i++)
       {
           bool found = false;     
           foreach (Tool tool in check)
           {
               if (tool.WerkzeugId == i)
               {
                   found = true;
                   break;
               }
           }
           if (!found) return i;
       }

       return 0;
    }
    public override string ToString()
    {
        return
            $"{nameof(WerkzeugId)}: {WerkzeugId}, {nameof(Bezeichnung)}: {Bezeichnung, -20}, {nameof(Preis)}: {Preis, 9:C2}, {nameof(Lagerbestand)}: {Lagerbestand}";
    }
    public void Print()
    {
        Console.WriteLine(ToString());
    }
}