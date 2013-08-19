using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Chrome_Issues
{
    public class ChatHub : Hub
    {
        //private static readonly ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();

        //public override Task OnConnected()
        //{
        //    dic.TryAdd(Context.ConnectionId, Context.ConnectionId);   
        //    return base.OnConnected();
        //}

        //public override Task OnDisconnected()
        //{
        //    string removedid;

        //    dic.TryRemove(Context.ConnectionId, out removedid);
        //    return base.OnDisconnected();
        //}

        public void Send(string message)
        {
            // Call the broadcastMessage method to update client.
            Clients.All.broadcastMessage(message);
        }
    }
}