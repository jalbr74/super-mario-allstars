namespace SuperMarioAllstarsTests.Utils;

public class StaticLogger
{
    private static readonly StringWriter StringWriter = new ();
    
    public static void Log(string message)
    {
        StringWriter.WriteLine(message);
        
        System.Console.WriteLine(message);
    }
    
    public static string GetLog()
    {
        return StringWriter.ToString();
    }
    
    public static void ClearLog()
    {
        StringWriter.GetStringBuilder().Clear();
    }
}
