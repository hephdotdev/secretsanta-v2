using System.Collections.Generic;
using System.Threading.Tasks;
namespace SecretSanta {
    class Program {
        static async Task Main(string[] args) {
            // Initialize data containers
            Data.Container.ChatClients = new Dictionary<string, Models.Client.TwitchChatClient>();
            
            // Build Chat Client
            // string userid = await Helpers.File.TryReadLineFromFileAsync(System.IO.Path.Join(System.Environment.CurrentDirectory, "SECRETS", "twitch.userid"));
            // Data.Container.ChatClients.TryAdd(userid, new Models.Client.TwitchChatClient();
            
            // Block the main thread
            await Task.Delay(-1);
        }
    }
}