using Microsoft.EntityFrameworkCore;
namespace SecretSanta.Data {
    public class SecretSantaContext : DbContext {
        public SecretSantaContext(): base() {}
        public DbSet<Models.Channel> Channels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string host = Helpers.File.TryReadLineFromFileAsync(System.IO.Path.Join(System.Environment.CurrentDirectory, "SECRETS", "pgsql.host")).GetAwaiter().GetResult();
            string port = Helpers.File.TryReadLineFromFileAsync(System.IO.Path.Join(System.Environment.CurrentDirectory, "SECRETS", "pgsql.port")).GetAwaiter().GetResult();
            string username = Helpers.File.TryReadLineFromFileAsync(System.IO.Path.Join(System.Environment.CurrentDirectory, "SECRETS", "pgsql.username")).GetAwaiter().GetResult();
            string password = Helpers.File.TryReadLineFromFileAsync(System.IO.Path.Join(System.Environment.CurrentDirectory, "SECRETS", "pgsql.password")).GetAwaiter().GetResult();
            string connection_string = $"Host={host};Port={port};Database=SecretSanta;Username={username};Password='{password}'";
            optionsBuilder.UseNpgsql(connection_string)
                          .UseSnakeCaseNamingConvention();
        }
    }
}