﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApplication
{
    public class ChatHub : Hub

    {
        public async Task Send(string message, string userName)
        {
            await this.Clients.All.SendAsync("Send", message, userName);
        }
    }
}