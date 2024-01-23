namespace NewCSVConsoleApp;

internal class Sorter
{
    internal class IdAsc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.WerkzeugId.CompareTo(y.WerkzeugId);
        }
    }
    
    internal class IdDesc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.WerkzeugId.CompareTo(y.WerkzeugId) * -1;
        }
    }
    
    internal class BezeichnungAsc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Bezeichnung.CompareTo(y.Bezeichnung);
        }
    }
    
    internal class BezeichnungDesc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Bezeichnung.CompareTo(y.Bezeichnung) * -1;
        }
    }
    
    internal class PreisAsc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Preis.CompareTo(y.Preis);
        }
    }
    
    internal class PreisDesc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Preis.CompareTo(y.Preis) * -1;
        }
    }
    
    internal class BestandAsc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Lagerbestand.CompareTo(y.Lagerbestand);
        }
    }
    
    internal class BestandDesc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Lagerbestand.CompareTo(y.Lagerbestand) * -1;
        }
    }  
    
    internal class BezeichnungLengthAsc:IComparer<Tool>
    {
        public int Compare(Tool? x, Tool? y)
        {
            return x.Bezeichnung.Length.CompareTo(y.Bezeichnung.Length);
        }
    }
}