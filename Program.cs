using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SecretSanta {
    class Program {
        static async Task Main(string[] args) {
            // Initialize data containers
            Data.Container.ChatClients = new Dictionary<string, Models.Client.TwitchChatClient>();
            
            // Setup database context
            var context = new Data.SecretSantaContext();
            
            // Fetch login data
            var user = context.Channels.Where(x => x.Name == "itssecretsanta").Single();

            // Build Chat Client
            Data.Container.ChatClients.TryAdd(user.Id, new Models.Client.TwitchChatClient(user.Name, user.Token, user.Name));
            Data.Container.ChatClients[user.Id].Client.Connect();
            
            // Block the main thread
            await Task.Delay(-1);
        }
    }
}