using Microsoft.AspNet.SignalR;
using Owin;
using Owin.Types;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebSocketsWorkersSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder
                .MapHubs(new HubConfiguration { EnableCrossDomain = true })
                .UseHandlerAsync(UpgradeToWebSockets);
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
            OwinWebSocketReceiveMessage received = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), socket.CallCancelled);

            while (socket.ClientCloseStatus == 0)
            {
                // Echo
                await socket.SendAsync(new ArraySegment<byte>(buffer, 0, received.Count), received.MessageType, received.EndOfMessage, socket.CallCancelled);

                received = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), socket.CallCancelled);
            }

            await socket.CloseAsync(socket.ClientCloseStatus, socket.ClientCloseDescription, socket.CallCancelled);
        }
    }
}
