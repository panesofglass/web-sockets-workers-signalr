using System;
using Microsoft.Owin.Hosting;

namespace WebSocketsWorkersSignalR
{
    static class Program
    {
        static void Main(string[] args)
        {
            const string uri = "http://localhost:5000/";
            using (WebApplication.Start<Startup>(uri))
            {
                Console.WriteLine("Ready, press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
