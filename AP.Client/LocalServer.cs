using System;
using System.Threading;

namespace AP.Client;

internal class LocalServer
{
    private readonly Thread _serverThread;
    private volatile bool _serverRunning = true;

    public LocalServer()
    {
        var server = new Server.Server();
        _serverThread = new Thread(() =>
        {
            try
            {
                server.Start();
                while (_serverRunning)
                {
                    server.Update();
                    Thread.Sleep(15);
                }

                server.Stop();
            }
            catch (Exception ex)
            {
                // log
            }
        })
        {
            IsBackground = true
        };
    }

    public void Start()
    {
        _serverThread.Start();
    }

    public void Stop()
    {
        _serverRunning = false;
        _serverThread.Join();
    }
}