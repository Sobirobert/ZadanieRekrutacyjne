namespace ZadanieRekrutacyjne.Patterns.Singleton;

public sealed class Singleton
{
    private static Singleton _instance = null;
    private static object _instanceLock = new object();
    public string StringProperty { get; set; }
    public int IntProperty { get; set; }

    private Singleton()
    {

    }

    public static Singleton GetInstance()
    {
        lock (_instanceLock)
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
        }
        return _instance;
    }
}
