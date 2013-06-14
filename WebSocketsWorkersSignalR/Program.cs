using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Owin;
using Microsoft.Owin.Hosting;
using System.Diagnostics;

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
                Process.Start(uri + "signalr/negotiate");
                Console.ReadKey();
            }
        }
    }
}
