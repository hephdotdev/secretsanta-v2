using System.Threading.Tasks;
namespace SecretSanta {
    class Program {
        static async Task Main(string[] args) {
            // Block the main thread
            await Task.Delay(-1);
        }
    }
}