using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Owin.Hosting;

namespace WebSocketsWorkersSignalR
{
    static class Program
    {
        static void Main(string[] args)
        {
            const string uri = "http://localhost:5000/";
            var options = new StartOptions();
            options.Urls.Add(uri);
            using (WebApp.Start<Startup>(options))
            {
                Process.Start(uri + "index.html");
                Console.WriteLine("Ready, press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
