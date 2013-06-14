using Owin;
using Owin.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketsWorkersSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Raw web sockets
            app.UseHandlerAsync(UpgradeToWebSockets);

            // SignalR Hubs
            app.MapHubs();
        }

        Task UpgradeToWebSockets(OwinRequest request, OwinResponse response, Func<Task> next)
        {
            if (!request.CanAccept)
                return next();

            request.Accept(WebSocketEcho);

            return Task.FromResult<object>(null);
        }

        async Task WebSocketEcho(OwinWebSocket socket)
        {
            byte[] buffer = new byte[1024];
            var received = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), socket.CallCancelled);

            while (socket.ClientCloseStatus == 0)
            {
                // Echo
                await socket.SendAsync(new ArraySegment<byte>(buffer), socket.CallCancelled);
                received = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), socket.CallCancelled);
            }

            await socket.CloseAsync(socket.ClientCloseStatus, socket.ClientCloseDescription, socket.CallCancelled);
        }
    }
}
