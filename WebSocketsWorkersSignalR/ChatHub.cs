using Microsoft.AspNet.SignalR;

namespace WebSocketsWorkersSignalR
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            // call the dynamic addMessage we created in the client.
            Clients.All.addMessage(message);
        }
    }
}
