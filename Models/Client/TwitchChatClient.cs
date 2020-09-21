using System;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;
namespace SecretSanta.Models.Client {
    class TwitchChatClient {
        public TwitchLib.Client.TwitchClient Client { get; }
        public TwitchChatClient (string channel_name, string token, string user_name) {
            ConnectionCredentials Credentials = new ConnectionCredentials(user_name, token);
            Client = new TwitchLib.Client.TwitchClient();
            Client.Initialize(Credentials, channel_name, '!', '@');
            Client.OnConnected           += async (sender, e) => { await Task.Run(() => OnConnected           (sender, e)); };
            Client.OnDisconnected        += async (sender, e) => { await Task.Run(() => OnDisconnected        (sender, e)); };
            Client.OnJoinedChannel       += async (sender, e) => { await Task.Run(() => OnJoinedChannel       (sender, e)); };
            Client.OnLeftChannel         += async (sender, e) => { await Task.Run(() => OnLeftChannel         (sender, e)); };
            Client.OnChatCommandReceived += async (sender, e) => { await Task.Run(() => OnChatCommandReceived (sender, e)); };
            Client.OnMessageSent         += async (sender, e) => { await Task.Run(() => OnMessageSent         (sender, e)); };
        }

        private Task OnConnected (object sender, OnConnectedArgs e) {
            Console.WriteLine($"{DateTime.UtcNow.ToString(Configuration.Application.DateFormat)}.DEBUG,CONNECTED,{this.Client.TwitchUsername}");
            return Task.CompletedTask;
        }
        private Task OnDisconnected (object sender, OnDisconnectedEventArgs e) {
            Console.WriteLine($"{DateTime.UtcNow.ToString(Configuration.Application.DateFormat)}.DEBUG,DISCONNECTED,{this.Client.TwitchUsername}");
            return Task.CompletedTask;
        }
        private Task OnJoinedChannel (object sender, OnJoinedChannelArgs e) {
            Console.WriteLine($"{DateTime.UtcNow.ToString(Configuration.Application.DateFormat)}.DEBUG,JOINED,#{e.Channel},{this.Client.TwitchUsername}");
            return Task.CompletedTask;
        }
        private Task OnLeftChannel (object sender, OnLeftChannelArgs e) {
            Console.WriteLine($"{DateTime.UtcNow.ToString(Configuration.Application.DateFormat)}.DEBUG,LEFT,#{e.Channel},{this.Client.TwitchUsername}");
            return Task.CompletedTask;
        }
        
        private Task OnChatCommandReceived (object sender, OnChatCommandReceivedArgs e) {
            Console.WriteLine($"{DateTime.UtcNow.ToString(Configuration.Application.DateFormat)}.DEBUG,CHATCMD,#{e.Command.ChatMessage.Channel},{e.Command.ChatMessage.Username},{e.Command.CommandIdentifier}{e.Command.CommandText}");
            return Task.CompletedTask;
        }
        private Task OnMessageSent (object sender, OnMessageSentArgs e) {
            return Task.CompletedTask;
        }
    }
}