using System.Threading.Tasks;
namespace SecretSanta.Helpers {
    class File {
        public static async Task<string> TryReadLineFromFileAsync (string path) {
            try {
                using (var reader = new System.IO.StreamReader(path)) {
                    return await reader.ReadLineAsync();
                }
            }
            catch {
                return null;
            }
        }
        public static async Task<bool> TryWriteLineToFileAsync (string line, string path, bool append) {
            try {
                using (var writer = new System.IO.StreamWriter(path, append)) {
                    await writer.WriteLineAsync(line);
                }
                return true;
            }
            catch {
                return false;
            }
        }
    }
}