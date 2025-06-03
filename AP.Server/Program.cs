namespace AP.Server;

public static class Program
{
    private static void Main()
    {
        var server = new Server();
        server.Start();

        while (true)
        {
            server.Update();
            Thread.Sleep(15);
        }
    }
}