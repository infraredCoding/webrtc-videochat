using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

namespace videochat.Hubs;

public class ChatHub : Hub
{
    public async Task JoinRoom(string roomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
    }

    public async Task SendOffer(string roomId, string offer)
    {
        await Clients.Others.SendAsync("ReceiveOffer", offer);
        
    }

    public async Task SendAnswer(string roomId, string answer)
    {
        await Clients.Others.SendAsync("ReceiveAnswer", answer);
    }

    public async Task SendIceCandidate(string roomId, string candidate)
    {
        await Clients.Others.SendAsync("ReceiveIceCandidate", candidate);
    }
    
}